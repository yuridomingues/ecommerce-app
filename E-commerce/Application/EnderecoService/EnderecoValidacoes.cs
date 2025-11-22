using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EnderecoInterfaces;
using Application.EnderecoDTO;
using Application.EnderecoExceptions;


namespace Application.EnderecoService
{
    public class EnderecoValidacoes : IEnderecoValidacoes
    {
        public void ValidarRua(CadastrarEnderecoDTO dto)
        {
           if (string.IsNullOrEmpty(dto.Rua))
            {
                throw new EnderecoVazio();
            }
           if (dto.Rua.All(char.IsDigit))
            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarNumero(CadastrarEnderecoDTO dto)
        {
            if (dto.Numero == null)
            {
                throw new EnderecoVazio();
            }
            
        }

        public void ValidarBairro(CadastrarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Bairro))
            {
                throw new EnderecoVazio();
            }
            if (dto.Bairro.All(char.IsDigit))
            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarCidade(CadastrarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Cidade))
            {
                throw new EnderecoVazio();
            }
            if (dto.Cidade.All(char.IsDigit))
            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarCep(CadastrarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.CEP))
            {
                throw new EnderecoVazio();
            }
            if (dto.CEP.All(char.IsLetter))
            {
                throw new EnderecoInvalido();
            }
            if (dto.CEP.Length != 8)
            {
                throw new CepErrado();
            }
        }

        public void ValidarEstado(CadastrarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Estado))
            {
                throw new EnderecoVazio();
            }
            if (dto.Estado.All(char.IsDigit))
            {
                throw new EnderecoInvalido();
            }
        }
    }
}
