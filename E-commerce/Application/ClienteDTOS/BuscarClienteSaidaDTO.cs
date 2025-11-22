using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EnderecoDTO;

namespace Application.Dtos
{
    public class BuscarClienteSaidaDTO
    {
        public Guid Id { get; set; } 

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string Cpf { get; set; } = string.Empty;

        public List<CadastrarEnderecoDTO> Enderecos { get; set; } = new();
    }
}
