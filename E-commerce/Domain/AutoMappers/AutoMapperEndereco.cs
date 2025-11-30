using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.AutoMappers;

public class AutoMapperEndereco : Profile
{
    
    public AutoMapperEndereco()
    {
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }

}
