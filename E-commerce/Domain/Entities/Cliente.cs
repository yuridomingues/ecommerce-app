using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }

        public string Nome { get; private set; } 

        public string Email { get; private set; } 

        public string SenhaHash { get; private set; } 

        public string Cpf { get; private set; } 

        List<Endereco> Enderecos { get; private set; } = new();

        public Cliente(string nome, string email, string senhahash, int id)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhahash;
            
        }
        public void DefinirId(int id)
        {
            Id = id;
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
