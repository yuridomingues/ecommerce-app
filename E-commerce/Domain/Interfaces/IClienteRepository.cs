using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        void CadastrarCliente(Cliente cliente);
        List<Cliente> ListarClientes();

        void RemoverCliente(Cliente cliente);
    }
}
