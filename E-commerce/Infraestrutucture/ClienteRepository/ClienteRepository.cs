using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infraestrutucture.Exceptions;


namespace Infraestrutucture.ClienteRepository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteDataBase _db;

        public ClienteRepository(IClienteDataBase db)
        {
            _db = db;
        }

        public void CadastrarCliente(Cliente cliente)
        {
           
            _db.CadastrarCliente(cliente);
           
        }

        public List<Cliente> ListarClientes()
        {
            return _db.ListarClientes();
        }

        public void RemoverCliente(Cliente cliente)
        {

           _db.RemoverCliente(cliente);

            
        }
        public void AlterarNome(Cliente cliente, string Novonome)
        {
            
            _db.AlterarNome(cliente, Novonome);

            

        }
        public void AlterarSenha(Cliente cliente, string NovaSenha)
        {

          _db.AlterarSenha(cliente, NovaSenha);
        }

        public void AlterarEmail(Cliente cliente, string NovoEmail)
        {
            Cliente? ClienteCadastrado = ( _db.BuscarEmail(cliente.Email));

            if (ClienteCadastrado == null)
            {
                throw new ClienteNaoExiste();

            }

            
             if (ClienteCadastrado.Senha != cliente.Senha)
            {
                throw new SenhaIncorreta();
            }
            else
            {
                _db.AlterarEmail(ClienteCadastrado, NovoEmail);
            }


        }

        public Cliente? BuscarClienteEspecifico(Cliente cliente)
        {
            Cliente? ClienteCadastrado = (_db.BuscarCpf(cliente.Cpf));

            if (ClienteCadastrado == null)
            {
                throw new ClienteNaoExiste();
            }
            else
            {
                return ClienteCadastrado;

            }
        }   

        public Cliente? BuscarId(Guid id)
        {
            return _db.BuscarId(id);
        }

        public Cliente? BuscarCpf(string cpf)
        {
            return _db.BuscarCpf(cpf);
        }

        public Cliente? BuscarEmail(string email)
        {
            return _db.BuscarEmail(email);
        }

       
    }
}
