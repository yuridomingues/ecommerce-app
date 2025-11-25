using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.ClienteExceptions;
using System.Linq.Expressions;

namespace Application.ClienteService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IValidacoesService _validacoes;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IValidacoesService validacoes, IMapper mapper)
        {
            _repository = repository;
            _validacoes = validacoes;
            _mapper = mapper;
        }
        public void CadastrarCliente(CadastroClienteDto dto)
        {
            _validacoes.ValidarNome(dto);
            _validacoes.ValidarEmail(dto);
            _validacoes.ValidarSenha(dto);
            _validacoes.ValidarCpf(dto);


            Cliente cliente = _mapper.Map<Cliente>(dto);

            BuscarCpfEmail(dto.Email, dto.Cpf);

            _repository.CadastrarCliente(cliente);

        }
        public List<ListarClientesDTO> ListarClientes()
        {
            List<Cliente> clientes = _repository.ListarClientes();
            return _mapper.Map<List<ListarClientesDTO>>(clientes);
        }
        public void RemoverCliente(RemoverClienteDTO dto)
        {
            Cliente clienteBuscado = BuscarEmail(dto.Email);

            if (clienteBuscado.Senha != dto.Senha)
            {
                throw new SenhaIncorreta();
            }

            _repository.RemoverCliente(clienteBuscado);
        }
        public void AlterarNome(NovoNomeClienteDTO dto)
        {
            _validacoes.ValidarNovoNome(dto);

            Cliente clienteBuscado = BuscarCpf(dto.Cpf);

            if (clienteBuscado.Senha != dto.Senha)
            {
                throw new SenhaIncorreta();
            }

            _repository.AlterarNome(clienteBuscado, dto.NovoNome);
        }
        public void AlterarSenha(AlterarSenhaDTO dto)
        {
            _validacoes.ValidarNovaSenha(dto);

            Cliente clienteBuscado = BuscarEmail(dto.Email);

            if (clienteBuscado.Senha != dto.Senha)
            {
                throw new SenhaIncorreta();
            }
            _repository.AlterarSenha(clienteBuscado, dto.NovaSenha);
        }

        public void AlterarEmail(AlterarEmailDTO dto)
        {
            _validacoes.ValidarNovoEmail(dto);

            Cliente clienteBuscado = BuscarEmail(dto.Email);

            if (clienteBuscado.Senha != dto.Senha)
            {
                throw new SenhaIncorreta();
            }

            _repository.AlterarEmail(clienteBuscado, dto.NovoEmail);
        }

        public BuscarClienteSaidaDTO BuscarClienteEspecifico(BuscarClienteEntradaDTO dto)
        {
            Cliente ClienteBuscado = BuscarCpf(dto.Cpf);

           BuscarClienteSaidaDTO clientesaidaDTO = _mapper.Map<BuscarClienteSaidaDTO>(ClienteBuscado);

            return clientesaidaDTO;
        }

        public Cliente BuscarCpf(string cpf)
        {
            Cliente clientecpf = _repository.BuscarCpf(cpf);

            if (clientecpf == null)
            {
                throw new ClienteNaoExiste();
            }
            else
            {
                return clientecpf;
            }


        }

        public Cliente BuscarEmail(string email)
        {
            Cliente clienteemail = _repository.BuscarEmail(email);

            if (clienteemail == null)
            {
                throw new ClienteNaoExiste();
            }
            else
            {
                return clienteemail;
            }
        }
        public void BuscarCpfEmail(string email, string cpf)
        {
            Cliente clientecpf = _repository.BuscarCpf(cpf);
            Cliente clienteemail = _repository.BuscarEmail(email);

            if (clientecpf != null || clienteemail != null)
            {
                throw new ClienteExistente();
            }


        }

    }

}

       