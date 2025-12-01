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

        public decimal PrecoUnitario { get; private set; }

        public decimal SubTotal => Quantidade * PrecoUnitario;

        public ItemCarrinho(Guid produtoid, int quantidade, decimal precounitario, string nome)
        {
            ProdutoId = produtoid;
            Quantidade = quantidade;
            PrecoUnitario = precounitario;
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

        public void AtualizarQuantidade(int NovaQuantidade)
        {
            if (NovaQuantidade <= 0)
            {
                throw new QuantidadeInvalida();
            }


            Quantidade = NovaQuantidade;
        }
    }
}