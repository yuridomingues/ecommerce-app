using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionsCarrinho
{
    public class CarrinhoSemProduto : Exception
    {
        public CarrinhoSemProduto()
            : base("Esse produto não está no seu carrinho.") { }
    }

    public class QuantidadeInvalida : Exception
    {
        public QuantidadeInvalida()
            : base("A quantidade tem que ser maior que 0.") { }
    }
    public class QuantidadeMaior : Exception
    {
        public QuantidadeMaior()
            : base("Você não pode remover uma quantidade maior do que a quantidade de produtos presentes no carrinho") { }
    }
}
