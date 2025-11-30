using AutoMapper;
using Application.DTOs;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.AutoMappers;

public class AutoMapperEndereco : Profile
{
    
    public AutoMapperEndereco()
    {
        CreateMap<Endereco, Domain.DTOs.EnderecoDTO>().ReverseMap();
    }

}
