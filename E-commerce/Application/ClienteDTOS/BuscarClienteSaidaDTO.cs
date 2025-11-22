using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BuscarClienteSaidaDTO
    {
        public Guid Id { get; set; } 

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string Cpf { get; set; } = string.Empty;

        public string? Rua { get; private set; }

        public int Numero { get; private set; }

        public string? Bairro { get; private set; }

        public string? Cidade { get; private set; }

        public string? CEP { get; private set; }

        public string? Estado { get; private set; }
    }
}
