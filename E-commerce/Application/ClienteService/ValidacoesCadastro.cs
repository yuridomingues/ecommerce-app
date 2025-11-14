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
    public class ValidacoesCadastro : IValidacoesService
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
            if (dto.SenhaHash.Length < 8 ||
               !dto.SenhaHash.Any(char.IsLetter) ||
               !dto.SenhaHash.Any(char.IsDigit) ||
               !dto.SenhaHash.Any(c => !char.IsLetterOrDigit(c))
               )
            {
                throw new SenhaInvalida();
            }
        }
        public void ValidarCpf(CadastroClienteDto dto)
        {

        }
    }
}
