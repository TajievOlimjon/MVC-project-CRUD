using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IMapperServices
{
    public class MapperService : Profile
    {


        public MapperService()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
        }
    
    }
}
