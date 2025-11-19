using AutoMapper;
using Domain.DTOs;

namespace Domain.AutoMappers;

public class AutoMapperEndereco : Profile
{
    
    public AutoMapperEndereco()
    {
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }

}
