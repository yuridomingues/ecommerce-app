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

            if (ClienteCadastrado == null)
            {
                _db.CadastrarCliente(cliente);
            }
            throw new ClienteExistente();
        }
    }
}
