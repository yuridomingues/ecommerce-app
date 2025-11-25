using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using System.Runtime.CompilerServices;

namespace Infraestrutucture.ClienteDataBase
{
    public class ClienteDataBase : IClienteDataBase
    {
        private readonly List<Cliente> clientes = new();

     



        public void CadastrarCliente(Cliente cliente)
        {
            cliente.DefinirId();
            
            clientes.Add(cliente);

           
        }

        public void RemoverCliente(Cliente cliente)
        {
            clientes.Remove(cliente);
        }
        public List<Cliente> ListarClientes()
        {
            return clientes.ToList();
        }
        public void AlterarNome(Cliente cliente, string NovoNome)
        {
            cliente.AlterarNome(NovoNome);
        }
        public void AlterarEmail(Cliente cliente, string NovoEmail)
        {
            cliente.AlterarEmail(NovoEmail);
        }
        public void AlterarSenha(Cliente cliente, string NovaSenha)
        {
            cliente.AlterarSenha(NovaSenha);
        }
        public Cliente? BuscarEmail(string email)
        {
            return clientes.FirstOrDefault(c => c.Email == email);
        }
        public Cliente? BuscarCpf(string cpf)
        {
            return clientes.FirstOrDefault(c => c.Cpf == cpf);
        }
        public Cliente? BuscarId(Guid id)
        {
            return clientes.FirstOrDefault(i => i.Id == id);
        }
        

 
       
    }

   
}
