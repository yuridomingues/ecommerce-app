using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Domain.AutoMappers;

public class AutoMapperEndereco : Profile
{
    
    public AutoMapperEndereco()
    {
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }

}
