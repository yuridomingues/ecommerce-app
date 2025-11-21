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

namespace Application.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IEnderecoValidacoes _validacoes;
        private readonly IMapper _mapper;


        public EnderecoService(IEnderecoValidacoes validacoes, IEnderecoRepository repository, IMapper mapper)
        {
            _validacoes = validacoes;
            _repository = repository;
            _mapper = mapper;
        }

        public void CadastrarEndereco(CadastrarEnderecoDTO dto, Guid id)
        {
            _validacoes.ValidarRua(dto);
            _validacoes.ValidarNumero(dto);
            _validacoes.ValidarBairro(dto);
            _validacoes.ValidarCidade(dto);
            _validacoes.ValidarCep(dto);
            _validacoes.ValidarEstado(dto);

            Endereco endereco = _mapper.Map<Endereco>(dto);




        }

    }
}
