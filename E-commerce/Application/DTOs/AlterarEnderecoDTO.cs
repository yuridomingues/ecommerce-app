using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnderecoDTO
{
    public class AlterarEnderecoDTO
    {
        public Guid Id { get; set; }
        public string? NovaRua { get;  set; }

        public int NovoNumero { get;  set; }

        public string? NovoBairro { get;  set; }

        public string? NovaCidade { get;  set; }

        public string? NovoCEP { get;  set; }

        public string? NovoEstado { get;  set; }
    }
}
