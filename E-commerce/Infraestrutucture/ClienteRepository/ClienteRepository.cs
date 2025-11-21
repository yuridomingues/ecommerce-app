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
            Cliente? ClienteCadastrado = _db.BuscarCliente(cliente.Email);
            Cliente? CpfCadastrado = _db.BuscarCpf(cliente.Cpf);

            if (ClienteCadastrado == null && CpfCadastrado == null)
            {
                _db.CadastrarCliente(cliente);
            }
            else
            {
                throw new ClienteExistente();

            }
        }

        public List<Cliente> ListarClientes()
        {
            return _db.ListarClientes();
        }

        public void RemoverCliente(Cliente cliente)
        {
            Cliente? ClienteCadastrado = _db.BuscarCliente(cliente.Email);

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
                _db.RemoverCliente(ClienteCadastrado);

            }
        }
        public void AlterarNome(Cliente cliente, string Novonome)
        {
            Cliente? ClienteCadastrado = _db.BuscarCpf(cliente.Cpf);

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
                _db.AlterarNome(ClienteCadastrado, Novonome);

            }

        }
        public void AlterarSenha(Cliente cliente, string NovaSenha)
        {
            Cliente? ClienteCadastrado = _db.BuscarCliente(cliente.Email);

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
                _db.AlterarSenha(ClienteCadastrado, NovaSenha);

            }

        }

        public void AlterarEmail(Cliente cliente, string NovoEmail)
        {
            Cliente? ClienteCadastrado = ( _db.BuscarCliente(cliente.Email));

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

       
    }
}
