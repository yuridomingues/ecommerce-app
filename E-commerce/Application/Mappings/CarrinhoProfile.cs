using Application.CarrinhoDTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoMappings
{
    public class CarrinhoProfile : Profile
    {
       public CarrinhoProfile()
       {
            
           
            CreateMap<ItemCarrinho, ListarCarrinhoDTO>()


                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.SubTotalItem, opt => opt.MapFrom(src => src.SubTotal));
        
        
       }
    }
}
