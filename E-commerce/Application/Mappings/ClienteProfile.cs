using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Dtos;

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






        }
    }
}
