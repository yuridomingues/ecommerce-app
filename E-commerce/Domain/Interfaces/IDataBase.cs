using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDataBase
    {
        void CadastrarCliente(Cliente cliente);
        void RemoverCliente(Cliente cliente);

        List<Cliente> ListarClientes();

        void AlterarNome(Cliente cliente, string NovoNome);
        void AlterarEmail(Cliente cliente, string NovoEmail);
        void AlterarSenha(Cliente cliente, string NovaSenha);

        Cliente? BuscarCliente(string email);

        Cliente? BuscarCpf(string cpf);


    }
}
