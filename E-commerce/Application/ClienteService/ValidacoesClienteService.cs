using Application.ClienteExceptions;
using Application.Dtos;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ValidacoesClienteService : IValidacoesService
    {
        public void ValidarNome(CadastroClienteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
            {
                throw new NomeValido();
            }
            if (!dto.Nome.All(c => char.IsLetter(c) || c == ' '))
               
            {
                throw new NomeLetra();
            }
        }

        public void ValidarEmail(CadastroClienteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new EmailVazio();
            }
            try
            {
                MailAddress mail = new MailAddress(dto.Email);
            }
            catch (FormatException)
            {
                throw new CadastroEmail();
            }
        }
        public void ValidarSenha(CadastroClienteDto dto)
        {
            if (dto.Senha.Length < 8 ||
               !dto.Senha.Any(char.IsLetter) ||
               !dto.Senha.Any(char.IsDigit) ||
               !dto.Senha.Any(c => !char.IsLetterOrDigit(c))
               )
            {
                throw new SenhaInvalida();
            }
            if (dto.Senha != dto.ConfirmarSenha)
            {
                throw new SenhasDiferentes();
            }
        }
        public void ValidarCpf(CadastroClienteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cpf))
            {
                throw new CpfVazio();
            }
            
            if (dto.Cpf.Length != 11 || !dto.Cpf.All(char.IsDigit))
                throw new CpfInvalido();

           
        }
        public void ValidarNovoNome(NovoNomeClienteDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NovoNome))
            {
                throw new NomeValido();
            }
            if (!dto.NovoNome.All(c => char.IsLetter(c) || c == ' '))

            {
                throw new NomeLetra();
            }
          
        }
        public void ValidarNovaSenha(AlterarSenhaDTO dto)
        {
            if (dto.NovaSenha.Length < 8 ||
              !dto.NovaSenha.Any(char.IsLetter) ||
              !dto.NovaSenha.Any(char.IsDigit) ||
              !dto.NovaSenha.Any(c => !char.IsLetterOrDigit(c))
              )
            {
                throw new SenhaInvalida();
            }
            if (dto.NovaSenha != dto.ConfirmarNovaSenha)
            {
                throw new SenhasDiferentes();
            }
        }

        public void ValidarNovoEmail(AlterarEmailDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new EmailVazio();
            }
            try
            {
                MailAddress mail = new MailAddress(dto.Email);
            }
            catch (FormatException)
            {
                throw new CadastroEmail();
            }
        }
    }
}
