using AutoMapper;
using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Dic_Categories, Categories>()
                .ForMember(x => x.Name, src => src.MapFrom(o => o.Cat_Name))
                .ForMember(x => x.Description, src => src.MapFrom(o => o.Cat_Description))
                .ForMember(x => x.CreationUser, src => src.MapFrom(o => o.Cat_CreationUserIdFk))
                .ForMember(x => x.Status, src => src.MapFrom(o => o.Cat_Status)).ReverseMap();
        }

    }
}
