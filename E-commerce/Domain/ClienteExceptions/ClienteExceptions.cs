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
}
