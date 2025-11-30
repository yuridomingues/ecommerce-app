using Application.EnderecoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnderecoInterfaces
{
    public interface IEnderecoService
    {
        void CadastrarEndereco(CadastrarEnderecoDTO dto,Guid clienteid);
        void RemoverEndereco(RemoverEnderecoDTO dto, Guid clienteid);

        void AlterarEndereco(AlterarEnderecoDTO dto, Guid clienteid);

    }
}
