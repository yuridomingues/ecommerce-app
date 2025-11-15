using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutucture.Exceptions
{
    public class ClienteExistente : Exception
    {
        public ClienteExistente()
            : base("Esse usuário já está cadastrado") { }
    }
}
