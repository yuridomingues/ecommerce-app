using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoDTO
{
    public class RemoverProdutoDTO
    {
        public Guid produtoid { get; set; }

        public int quantidade { get; set; }

        public string nome { get; set; }
    }
}
