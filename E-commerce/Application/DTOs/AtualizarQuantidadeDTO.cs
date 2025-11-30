using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoDTO
{
    public class AtualizarQuantidadeDTO
    {
        public Guid produtoid { get; set; }

        public int Novaquantidade { get; set; }
    }
}
