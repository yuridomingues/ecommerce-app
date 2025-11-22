using Application.EnderecoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EnderecoService;
using Application.EnderecoDTO;

namespace Application.EnderecoInterfaces
{
    public interface IEnderecoService
    {
        void CadastrarEndereco(CadastrarEnderecoDTO dto,Guid clienteid);
    }
}
