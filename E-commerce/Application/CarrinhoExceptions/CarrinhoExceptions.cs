using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoExceptions
{
    public class ProdutoNaoExiste : Exception
    {
        public ProdutoNaoExiste()
            : base("Esse produto não foi encontrado no cadastro, verifique se o nome corresponde ao id") { }
    }

    public class CarrinhoNaoExiste : Exception
    {
        public CarrinhoNaoExiste()
            : base("Esse carrinho não existe") { }
    }


}
