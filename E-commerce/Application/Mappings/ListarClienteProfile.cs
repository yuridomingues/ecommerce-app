using Application.Dtos;
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
    public class ListarClienteProfile : Profile
    {
        public ListarClienteProfile()
        {
            CreateMap<Cliente, ListarClientesDTO>();

        }


    }
}
