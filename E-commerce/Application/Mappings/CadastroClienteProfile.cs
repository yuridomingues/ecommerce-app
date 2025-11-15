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
    public class CadastroClienteProfile : Profile
    {
        public CadastroClienteProfile()
        {
            CreateMap<CadastroClienteDto, Cliente>()
    .ConstructUsing(dto => new Cliente(
        dto.Nome,
        dto.Email,
        dto.SenhaHash,
        dto.Cpf 
    ));
        }
    }
}
