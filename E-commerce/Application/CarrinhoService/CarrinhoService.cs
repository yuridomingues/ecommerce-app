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

        public CarrinhoService(IClienteRepository repository, IProdutoRepository produtorepository, ICarrinhoRepository carrinrepository)
        {
            _repository = repository;
            _produtoRepository = produtorepository;
            _carrinrepository = carrinrepository;
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

     

        
    }

}
