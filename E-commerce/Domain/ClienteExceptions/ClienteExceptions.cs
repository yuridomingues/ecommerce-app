using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClienteExceptions
{
    public class NomesIguais : Exception
    {
        public NomesIguais()
            : base("O novo nome tem que ser diferente do antigo") { }            
            
    }
    public class EmailsIguais : Exception
    {
        public EmailsIguais()
            : base("O novo Email tem que ser diferente do antigo") { }
    }
}
