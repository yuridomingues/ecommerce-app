using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnderecoExceptions
{
    public class EnderecoVazio : Exception
    {
        public EnderecoVazio()
            : base ("Esse campo não pode ser vazio") { }
    }

    public class EnderecoInvalido : Exception
    {
        public EnderecoInvalido()
            : base("Tem certeza que é o seu endereço?") { }
    }

    public class CepErrado : Exception
    {
        public CepErrado()
            : base("O CEP deve ter 8 dígitos") { }
    }
}
