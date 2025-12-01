using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoDTO
{
    public class AdicionarProdutoCarrinhoDTO
    {

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public string Nome { get; set; } = string.Empty;

    }
}
