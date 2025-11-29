using Domain.ExceptionsCarrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Carrinho
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid ClienteId { get; private set; }

        public List<ItemCarrinho> itens { get; private set; } = new();

        public IReadOnlyList<ItemCarrinho> Item => itens;

        public Carrinho(Guid clienteid)
        {
            ClienteId = clienteid;
        }

        public ItemCarrinho? BuscarIdProduto(Guid id)
        {
            return itens.FirstOrDefault(i => i.ProdutoId == id);
        }



        public void AdicionarProduto(ItemCarrinho item)
        {
            ItemCarrinho? BuscarProduto = BuscarIdProduto(item.ProdutoId);

            if (BuscarProduto != null)
            {
                BuscarProduto.AdicionarQuantidade(item.Quantidade);
            }
            else
            {
                itens.Add(item);
            }
        }

        public void RemoverProduto(ItemCarrinho item)
        {
            ItemCarrinho? BuscarProduto = BuscarIdProduto(item.ProdutoId);

            if (BuscarProduto == null)
            {
                throw new CarrinhoSemProduto();

            }
            if (item.Quantidade == BuscarProduto.Quantidade)
            {
                itens.Remove(BuscarProduto);
            }
            else
            {
                BuscarProduto.RemoverQuantidade(item.Quantidade);
            }

        }

        public ItemCarrinho AtualizarQuantidade(int NovaQuantidade, Guid produtoid)
        {
            ItemCarrinho? BuscarProduto = BuscarIdProduto(produtoid);

            if (BuscarProduto == null)
            {
                throw new CarrinhoSemProduto();
            }
            BuscarProduto.AtualizarQuantidade(NovaQuantidade);
            return BuscarProduto;
        }

        public void EsvaziarCarrinho()
        {

            itens.Clear();
        }

        public decimal CalcularSubTotal()
        {
            return itens.Sum(i => i.SubTotal);
        }

       


    }
}