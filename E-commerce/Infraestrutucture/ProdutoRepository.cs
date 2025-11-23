using Domain.Entitities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();
        private int _proximoId = 1;

        public void Adicionar(Produto produto)
        {
            typeof(Produto).GetProperty("Id")
                ?.SetValue(produto, _proximoId++);

            _produtos.Add(produto);
        }

        public Produto ObterPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtos;
        }

        public void Atualizar(Produto produto)
        {
            var index = _produtos.FindIndex(p => p.Id == produto.Id);
            if (index != -1)
            {
                _produtos[index] = produto;
            }
        }

        public void Remover(int id)
        {
            var produto = ObterPorId(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}