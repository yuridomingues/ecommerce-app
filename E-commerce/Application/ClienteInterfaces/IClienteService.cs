using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IClienteService
    {
        void CadastrarCliente(CadastroClienteDto dto);

        List<ListarClientesDTO> ListarClientes();

        void RemoverCliente(RemoverClienteDTO dto);

        void AlterarNome(NovoNomeClienteDTO dto);
        void AlterarSenha(AlterarSenhaDTO dto);

        void AlterarEmail(AlterarEmailDTO dto);

        BuscarClienteSaidaDTO BuscarClienteEspecifico(BuscarClienteEntradaDTO dto);

        Cliente BuscarEmail(string email);
        Cliente BuscarCpf(string cpf);
        void BuscarCpfEmail(string email, string cpf);

    }
}
