using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IValidacoesService
    {
        void ValidarNome(CadastroClienteDto dto);
        void ValidarEmail(CadastroClienteDto dto);
        void ValidarSenha(CadastroClienteDto dto);
        void ValidarCpf(CadastroClienteDto dto);

        void ValidarNovoNome(NovoNomeClienteDTO dto);

        void ValidarNovaSenha(AlterarSenhaDTO dto);



    }
}
