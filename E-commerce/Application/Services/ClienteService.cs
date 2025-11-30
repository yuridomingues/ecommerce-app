using Domain.Interfaces;
using System;
using System.Collections.Generic;
using Application.Interfaces;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.ClienteExceptions;

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

            Cliente clienteCpf = _repository.BuscarCpf(dto.Cpf);
            Cliente clienteEmail = _repository.BuscarEmail(dto.Email);

            if (clienteCpf != null || clienteEmail != null)
                throw new ClienteExistente();

            Cliente cliente = _mapper.Map<Cliente>(dto);
            _repository.CadastrarCliente(cliente);
        }

        public List<ListarClientesDTO> ListarClientes()
        {
            List<Cliente> clientes = _repository.ListarClientes();
            List<ListarClientesDTO> dtoList = _mapper.Map<List<ListarClientesDTO>>(clientes);
            return dtoList;
        }

        public void RemoverCliente(RemoverClienteDTO dto)
        {
            Cliente clienteBuscado = _repository.BuscarEmail(dto.Email);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            if (clienteBuscado.Senha != dto.Senha)
                throw new SenhaIncorreta();

            _repository.RemoverCliente(clienteBuscado);
        }

        public void AlterarNome(NovoNomeClienteDTO dto)
        {
            _validacoes.ValidarNovoNome(dto);

            Cliente clienteBuscado = _repository.BuscarCpf(dto.Cpf);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            if (clienteBuscado.Senha != dto.Senha)
                throw new SenhaIncorreta();

            _repository.AlterarNome(clienteBuscado, dto.NovoNome);
        }

        public void AlterarSenha(AlterarSenhaDTO dto)
        {
            _validacoes.ValidarNovaSenha(dto);

            Cliente clienteBuscado = _repository.BuscarEmail(dto.Email);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            if (clienteBuscado.Senha != dto.Senha)
                throw new SenhaIncorreta();

            _repository.AlterarSenha(clienteBuscado, dto.NovaSenha);
        }

        public void AlterarEmail(AlterarEmailDTO dto)
        {
            _validacoes.ValidarNovoEmail(dto);

            Cliente clienteBuscado = _repository.BuscarEmail(dto.Email);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            if (clienteBuscado.Senha != dto.Senha)
                throw new SenhaIncorreta();

            Cliente emailNovoBuscado = _repository.BuscarEmail(dto.NovoEmail);
            if (emailNovoBuscado != null)
                throw new ClienteExistente();

            _repository.AlterarEmail(clienteBuscado, dto.NovoEmail);
        }

        public BuscarClienteSaidaDTO BuscarClienteEspecifico(BuscarClienteEntradaDTO dto)
        {
            Cliente clienteBuscado = _repository.BuscarCpf(dto.Cpf);

            if (clienteBuscado == null)
                throw new ClienteNaoExiste();

            BuscarClienteSaidaDTO dtoSaida = _mapper.Map<BuscarClienteSaidaDTO>(clienteBuscado);
            return dtoSaida;
        }
    }
}
