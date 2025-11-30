using Application.CarrinhoDTO;
using Application.CarrinhoExceptions;
using Application.CarrinhoInterfaces;
using Application.ClienteExceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Entitities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoService
{
    public class ValidarCarrinho : IValidarCarrinho
    {
        private readonly IClienteRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICarrinhoRepository _carrinrepository;

        public ValidarCarrinho(IClienteRepository repository, IProdutoRepository produtorepository, ICarrinhoRepository carrinrepository)
        {
            _repository = repository;
            _produtoRepository = produtorepository;
            _carrinrepository = carrinrepository;
        }
        public (Carrinho Carrinho, Produto Produto) ValidarRecursos(AtualizarQuantidadeDTO dto, Guid clienteid)
        {
            Cliente clienteBuscado = _repository.BuscarId(clienteid);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            Produto produtoBuscado = _produtoRepository.ObterPorId(dto.produtoid);

            if (produtoBuscado == null)
                throw new ProdutoNaoExiste();

            Carrinho? carrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (carrinho == null)
            {
                throw new CarrinhoNaoExiste();
            }

           

            return (carrinho, produtoBuscado);

        }

        public (Carrinho Carrinho, Cliente cliente) ValidarRecursosEsvaziar(Guid clienteid)
        {
            Cliente clienteBuscado = _repository.BuscarId(clienteid);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            Carrinho carrinho = _carrinrepository.BuscarClienteId(clienteid);

            if (carrinho == null)
            {
                throw new CarrinhoNaoExiste();
            }

            return (carrinho, clienteBuscado);
    }    }
}
