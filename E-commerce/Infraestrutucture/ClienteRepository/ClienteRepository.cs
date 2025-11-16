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
        private readonly IDataBase _db;

        public ClienteRepository(IDataBase db)
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

            if (ClienteCadastrado != null)
            {
                _db.RemoverCliente(ClienteCadastrado);
            }
            else
            {
                throw new ClienteNaoExiste();
            }
        }
        public void AlterarNome(Cliente cliente, string Novonome)
        {
            Cliente? ClienteCadastrado = _db.BuscarCpf(cliente.Cpf);

            if (ClienteCadastrado != null)
            {
                _db.AlterarNome(ClienteCadastrado, Novonome);
            }
            else
            {
                throw new ClienteNaoExiste();
            }

        }
        public void AlterarSenha(Cliente cliente, string NovaSenha)
        {
            Cliente? ClienteCadastrado = _db.BuscarCliente(cliente.Email);

            if (ClienteCadastrado != null)
            {
                _db.AlterarSenha(ClienteCadastrado, NovaSenha);
            }
            else
            {
                throw new ClienteNaoExiste();
            }

        }
    }
}
