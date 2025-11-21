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

namespace Application.ClienteService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository  _repository;
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

            _repository.CadastrarCliente(cliente);
            
        }
        public List<ListarClientesDTO> ListarClientes()
        {
            List<Cliente> clientes = _repository.ListarClientes();
            return _mapper.Map<List<ListarClientesDTO>>(clientes);
        }
        public void RemoverCliente(RemoverClienteDTO dto)
        {
            Cliente cliente = _mapper.Map<Cliente>(dto);

            _repository.RemoverCliente(cliente);
        }
        public void AlterarNome(NovoNomeClienteDTO dto)
        {
            _validacoes.ValidarNovoNome(dto);

            Cliente cliente = _mapper.Map<Cliente>(dto);

            _repository.AlterarNome(cliente, dto.NovoNome);
        }
        public void AlterarSenha(AlterarSenhaDTO dto)
        {
            _validacoes.ValidarNovaSenha(dto);

            Cliente cliente = _mapper.Map<Cliente>(dto);

            _repository.AlterarSenha(cliente, dto.NovaSenha);
        }

        public void AlterarEmail(AlterarEmailDTO dto)
        {
            _validacoes.ValidarNovoEmail(dto);

            Cliente? cliente = _mapper.Map<Cliente>(dto);

            _repository.AlterarEmail(cliente, dto.NovoEmail);
        }

        public BuscarClienteSaidaDTO? BuscarClienteEspecifico(BuscarClienteEntradaDTO dto)
        {
            Cliente clienteentrada = _mapper.Map<Cliente>(dto);


            Cliente clienteencontrado = _repository.BuscarClienteEspecifico(clienteentrada);

            BuscarClienteSaidaDTO clientesaidaDTO = _mapper.Map<BuscarClienteSaidaDTO>(clienteencontrado);


            return clientesaidaDTO;

        } 
    }
}
