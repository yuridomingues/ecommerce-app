using Domain.Entitities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infraestrutucture.ProdutoRepository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public void Adicionar(Produto produto)
        {
           

            _produtos.Add(produto);
        }

        public Produto? ObterPorId(Guid id)
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

        public void Remover(Guid id)
        {
            var produto = ObterPorId(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}