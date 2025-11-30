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
           if (dto.Rua.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
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
            if (dto.Bairro.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

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
            if (dto.Cidade.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

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
            if (dto.CEP.Any(c => !char.IsDigit(c)))
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
            if (dto.Estado.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarNovaRua(AlterarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.NovaRua))
            {
                throw new EnderecoVazio();
            }
            if (dto.NovaRua.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarNovoNumero(AlterarEnderecoDTO dto)
        {
            if (dto.NovoNumero == null)
            {
                throw new EnderecoVazio();
            }

        }

        public void ValidarNovoBairro(AlterarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.NovoBairro))
            {
                throw new EnderecoVazio();
            }
            if (dto.NovoBairro.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarNovaCidade(AlterarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.NovaCidade))
            {
                throw new EnderecoVazio();
            }
            if (dto.NovaCidade.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

            {
                throw new EnderecoInvalido();
            }
        }

        public void ValidarNovoCep(AlterarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.NovoCEP))
            {
                throw new EnderecoVazio();
            }
            if (dto.NovoCEP.Any(c => !char.IsDigit(c)))
            {
                throw new EnderecoInvalido();
            }
            if (dto.NovoCEP.Length != 8)
            {
                throw new CepErrado();
            }
        }

        public void ValidarNovoEstado(AlterarEnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.NovoEstado))
            {
                throw new EnderecoVazio();
            }
            if (dto.NovoEstado.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))

            {
                throw new EnderecoInvalido();
            }
        }


    }
}
