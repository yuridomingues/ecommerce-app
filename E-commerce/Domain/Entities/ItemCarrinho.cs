using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ExceptionsCarrinho;

namespace Domain.Entities
{
    public class ItemCarrinho
    {
       public Guid ProdutoId { get; private set; }

       public int Quantidade { get; private set; }

       public string Nome { get; private set; }

       public ItemCarrinho(Guid produtoid, int quantidade, string nome)
        {
            ProdutoId = produtoid;
            Quantidade = quantidade;
            Nome = nome;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new QuantidadeInvalida();
            }
            Quantidade += quantidade;
        }

        public void RemoverQuantidade(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new QuantidadeInvalida();
            }
            if (quantidade > Quantidade)
            {
                throw new QuantidadeMaior();
            }
            Quantidade -= quantidade;
        }
    }
}
