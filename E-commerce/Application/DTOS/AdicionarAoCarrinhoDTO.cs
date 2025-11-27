using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class AdicionarAoCarrinhoDTO
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }
    }
}
