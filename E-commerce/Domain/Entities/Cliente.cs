using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; } 

        public string Email { get; private set; } 

        public string SenhaHash { get; private set; } 

        public string Cpf { get; private set; } 

   

        public void DefinirId()
        {
            this.Id = Guid.NewGuid();
        }
        public void AlterarNome(string NovoNome)
        {
            Nome = NovoNome;
        }
        public void AlterarEmail(string NovoEmail)
        {
            Email = NovoEmail;
        }
        public void AlterarSenha(string NovaSenha)
        {
            SenhaHash = NovaSenha;
        }
        

        

    }
}
