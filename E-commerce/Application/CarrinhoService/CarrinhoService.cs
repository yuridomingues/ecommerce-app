using Application.CarrinhoDTO;
using Application.CarrinhoInterfaces;
using Application.ClienteExceptions;
using Domain.Entities;
using Domain.Entitities;
using Domain.ExceptionsCarrinho;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CarrinhoExceptions;
using Application.CarrinhoMappings;
using AutoMapper;

 


namespace Application.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IClienteRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICarrinhoRepository _carrinrepository;
        private readonly IMapper _mapper;
        private readonly IValidarCarrinho _validar;

        public CarrinhoService(IClienteRepository repository, IProdutoRepository produtorepository, ICarrinhoRepository carrinrepository, IMapper mapper, IValidarCarrinho validar)
        {
            _repository = repository;
            _produtoRepository = produtorepository;
            _carrinrepository = carrinrepository;
            _mapper = mapper;
            _validar = validar;
        }

        public void AdicionarProdutoCarrinho(AdicionarProdutoCarrinhoDTO dto, Guid clienteid)
        {
            Cliente? cliente = _repository.BuscarId(clienteid);

            if (cliente == null)
                throw new ClienteNaoExiste();

            Produto? produto = _produtoRepository.ObterPorId(dto.ProdutoId);

            if (produto == null)
                throw new ProdutoNaoExiste();
            Carrinho? carrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (carrinho == null)
            {
                carrinho = new Carrinho(clienteid);
            }

            ItemCarrinho item = new ItemCarrinho(produto.Id, dto.Quantidade, produto.Preco, dto.Nome);

            carrinho.AdicionarProduto(item);

            _carrinrepository.Salvar(carrinho);

        } 

        public List<ListarCarrinhoDTO> ListarItensCarrinho(Guid clienteid)
        {
            Cliente clienteBuscado = _repository.BuscarId(clienteid);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            Carrinho BuscarCarrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (BuscarCarrinho == null)
            {
                return new List<ListarCarrinhoDTO>();
            }

            return _mapper.Map<List<ListarCarrinhoDTO>>(BuscarCarrinho.Item);


        }

        public void RemoverProduto(Guid clienteid, RemoverProdutoDTO dto)
        {
            Cliente clienteBuscado = _repository.BuscarId(clienteid);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            Produto produtoBuscado = _produtoRepository.ObterPorId(dto.produtoid);

            if (produtoBuscado == null)
                throw new ProdutoNaoExiste();

            if (produtoBuscado.Nome != dto.nome)
            {
                throw new ProdutoNaoExiste();
            }
            
            Carrinho? carrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (carrinho == null)
            {
                throw new CarrinhoNaoExiste();
            }

          

            ItemCarrinho item = new ItemCarrinho(produtoBuscado.Id, dto.quantidade, produtoBuscado.Preco, dto.nome);

            carrinho.RemoverProduto(item);

            _carrinrepository.Salvar(carrinho);
        }

        public void AtualizarQuantidade(AtualizarQuantidadeDTO dto, Guid clienteid)
        {
            var recursos = _validar.ValidarRecursos(dto, clienteid);
            recursos.Carrinho.AtualizarQuantidade(dto.Novaquantidade, recursos.Produto.Id);

            _carrinrepository.Salvar(recursos.Carrinho);
        }

        public void EsvaziarCarrinho(Guid clienteid)
        {
            (Carrinho carrinho, Cliente cliente) = _validar.ValidarRecursosEsvaziar(clienteid);

            carrinho.EsvaziarCarrinho();

            _carrinrepository.Salvar(carrinho);

        }

        public decimal ObterSubTotal(Guid clienteid)
        {
            Carrinho? carrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (carrinho == null)
            {
                return 0m;
            }

            return carrinho.CalcularSubTotal();
        }




    }

}
