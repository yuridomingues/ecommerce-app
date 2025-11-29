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
            : base("Esse produto não foi encontrado no cadastro") { }
    }
}
