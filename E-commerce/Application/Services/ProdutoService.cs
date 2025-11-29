using Domain.Entitities;
using Domain.Interfaces;
using Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using Application.ProdutoInterface;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        // Injeção de dependência do repositório para baixo acoplamento
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void CadastrarProduto(CriarProdutoDto dto)
        {
            // Transforma DTO em entidade
            var novoProduto = new Produto(dto.Nome, dto.Preco, dto.EstoqueInicial);
            _produtoRepository.Adicionar(novoProduto);
        }

        public IEnumerable<ProdutoDto> ListarTodos()
        {
            var produtos = _produtoRepository.ObterTodos();
            // Transforma entidades em DTOs para output
            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Estoque = p.Estoque
            });
        }  

        public ProdutoDto ObterPorId(Guid Id)
        {
            var p = _produtoRepository.ObterPorId(Id);
            if (p == null) return null;

            return new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Estoque = p.Estoque
            };
        }

        public void AtualizarPreco(Guid Id, decimal novoPreco)
        {
            var produto = _produtoRepository.ObterPorId(Id);
            if (produto == null) throw new Exception("Produto não encontrado");
        
            produto.AtualizarPreco(novoPreco);
            _produtoRepository.Atualizar(produto);
        }
    }
}