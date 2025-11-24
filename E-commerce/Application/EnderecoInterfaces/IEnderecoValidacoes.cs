using Application.EnderecoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.EnderecoInterfaces
{
    public interface IEnderecoValidacoes
    {
        void ValidarRua(CadastrarEnderecoDTO dto);
        void ValidarNumero(CadastrarEnderecoDTO dto);

        void ValidarBairro(CadastrarEnderecoDTO dto);

        void ValidarCidade(CadastrarEnderecoDTO dto);

        void ValidarCep(CadastrarEnderecoDTO dto);

        void ValidarEstado(CadastrarEnderecoDTO dto);

        void ValidarNovaRua(AlterarEnderecoDTO dto);
        void ValidarNovoNumero(AlterarEnderecoDTO dto);

        void ValidarNovoBairro(AlterarEnderecoDTO dto);

        void ValidarNovaCidade(AlterarEnderecoDTO dto);

        void ValidarNovoCep(AlterarEnderecoDTO dto);

        void ValidarNovoEstado(AlterarEnderecoDTO dto);


    }
}
