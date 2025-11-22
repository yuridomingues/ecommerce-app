using Application.EnderecoDTO;
using Application.EnderecoInterfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.ClienteExceptions;


namespace Application.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoValidacoes _validacoes;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;


        public EnderecoService(IEnderecoValidacoes validacoes, IMapper mapper, IClienteRepository repository)
        {
            _validacoes = validacoes;
            _mapper = mapper;
            _repository = repository;
        }

        public void CadastrarEndereco(CadastrarEnderecoDTO dto, Guid clienteid)
        {
            _validacoes.ValidarRua(dto);
            _validacoes.ValidarNumero(dto);
            _validacoes.ValidarBairro(dto);
            _validacoes.ValidarCidade(dto);
            _validacoes.ValidarCep(dto);
            _validacoes.ValidarEstado(dto);

            Endereco endereco = _mapper.Map<Endereco>(dto);

            Cliente? cliente = _repository.BuscarId(clienteid);

            if (cliente == null)
            {
                throw new ClienteNaoExiste();
            }

            cliente.CadastrarEndereco(endereco);

        }

    }
}
