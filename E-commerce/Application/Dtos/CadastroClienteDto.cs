using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CadastroClienteDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string SenhaHash { get;  set; } = string.Empty;

        public string ConfirmarSenhaHash { get; set; } = string.Empty;

        public string Cpf { get;  set; } = string.Empty;
    }
}
