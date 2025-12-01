using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.EnderecoDTO;
using AutoMapper;

namespace Application.EnderecoMappings
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CadastrarEnderecoDTO, Endereco>();



        }
    }
}
