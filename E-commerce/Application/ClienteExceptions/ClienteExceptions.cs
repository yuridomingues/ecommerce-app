using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClienteExceptions
{
    public class NomeValido : Exception
    {
        public NomeValido()
            : base("O nome precisar ser preenchido ") { }
    }
    public class NomeLetra : Exception
    {
        public NomeLetra()
        : base("Tem certeza que esse é o seu nome") { }
    }
    public class EmailVazio : Exception
    {
        public EmailVazio()
            : base("O email precisa ser preenchido") { }
    }
    public class CadastroEmail : Exception
    {
        public CadastroEmail()
            : base("Digite um email válido") { }
    }
    public class SenhaInvalida : Exception
    {
        public SenhaInvalida()
            : base("Escolha uma senha mais segura. Use uma combinação de letras, números e símbolos.") { }
    }
    public class CpfInvalido : Exception
    {
        public CpfInvalido()
            : base("Esse CPF é inválido") { }
    }
    public class CpfVazio : Exception
    {
        public CpfVazio()
            : base("O CPF tem que ser preenchido") { }
    }

    public class SenhasDiferentes : Exception
    {
        public SenhasDiferentes()
            : base("As senhas precisam ser iguais. ") { }
    }


}
