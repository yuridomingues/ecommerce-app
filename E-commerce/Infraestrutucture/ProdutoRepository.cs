namespace Infraestructure.ProdutoRepository
{
    using E_commerce.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class ProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public Produto ObterProdutoPorId(int id)
        {
            return _produtos.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            return _produtos;
        }

        public void AtualizarProduto(Produto produtoAtualizado)
        {
            var produto = ObterProdutoPorId(produtoAtualizado.Id);
            if (produto != null)
            {
                produto.Nome = produtoAtualizado.Nome;
                produto.Preco = produtoAtualizado.Preco;
                produto.Estoque = produtoAtualizado.Estoque;
            }
        }

        public void RemoverProduto(int id)
        {
            var produto = ObterProdutoPorId(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}