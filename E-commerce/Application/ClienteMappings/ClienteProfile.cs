using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Dtos;
using Application.EnderecoDTO;

namespace Application.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CadastroClienteDto, Cliente>();
            CreateMap<Cliente, ListarClientesDTO>();
            CreateMap<RemoverClienteDTO, Cliente>();
            CreateMap<NovoNomeClienteDTO, Cliente>();
            CreateMap<AlterarSenhaDTO, Cliente>();
            CreateMap<AlterarEmailDTO, Cliente>();
            CreateMap<BuscarClienteEntradaDTO, Cliente>();
            CreateMap<Cliente, BuscarClienteSaidaDTO>();
            CreateMap<Cliente, BuscarClienteSaidaDTO>()
    .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos));

            CreateMap<Endereco, CadastrarEnderecoDTO>();

            CreateMap<CadastrarEnderecoDTO, Endereco>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));



        }
    }
}
