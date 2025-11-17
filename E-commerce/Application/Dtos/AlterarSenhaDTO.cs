using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public  class AlterarSenhaDTO
    {
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;

        public string NovaSenhaHash { get; set; } = string.Empty;

        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}
