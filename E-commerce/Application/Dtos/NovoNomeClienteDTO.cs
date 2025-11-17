using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class NovoNomeClienteDTO
    {
        public string Cpf { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;
        public string NovoNome { get; set; } = string.Empty;

    }
}
