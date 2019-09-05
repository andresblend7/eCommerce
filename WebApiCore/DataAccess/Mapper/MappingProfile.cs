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
        /// <summary>
        /// Clase Encargada de mapear las conversiones de entidades a structure's
        /// </summary>
        public MappingProfile()
        {

             /*
                Perfil de mapeo de entidades.
                Se mapean las entidades con sus respectivos Structure Models para 
                proporcionar una comunicaciòn segura /DTO/
             */

            //Productos
            CreateMap<Dic_Products, Product>()
                .ForMember(x => x.Id , src => src.MapFrom(o => o.Id))
                .ForMember(x => x.CategoryId, src => src.MapFrom(o => o.Pro_CategoryIdFk))
                .ForMember(x => x.CreationUserId, src => src.MapFrom(o => o.Pro_CreationUserIdFk))
                .ForMember(x => x.CityId, src => src.MapFrom(o => o.Pro_CityIdFk))
                .ForMember(x => x.GuId, src => src.MapFrom(o => o.Pro_GuId))
                .ForMember(x => x.Condition, src => src.MapFrom(o => o.Pro_Condition))
                .ForMember(x => x.Name, src => src.MapFrom(o => o.Pro_Name))
                .ForMember(x => x.Description, src => src.MapFrom(o => o.Pro_Description))
                .ForMember(x => x.Price, src => src.MapFrom(o => o.Pro_Price))
                .ForMember(x => x.Stock, src => src.MapFrom(o => o.Pro_Stock))
                .ForMember(x => x.OutletPrice, src => src.MapFrom(o => o.Pro_OutletPrice))
                .ForMember(x => x.IsOutlet, src => src.MapFrom(o => o.Pro_IsOutlet))
                .ForMember(x => x.PrincipalImage, src => src.MapFrom(o => o.Pro_PrincipalImage))
                .ForMember(x => x.CreationDate, src => src.MapFrom(o => o.Pro_CreationDate))
                .ForMember(x => x.Status, src => src.MapFrom(o => o.Pro_status));


            //Categorias
            CreateMap<Dic_Categories, Category>()
                .ForMember(x => x.Name, src => src.MapFrom(o => o.Cat_Name))
                .ForMember(x => x.Description, src => src.MapFrom(o => o.Cat_Description))
                .ForMember(x => x.CreationUser, src => src.MapFrom(o => o.Cat_CreationUserIdFk))
                .ForMember(x => x.Status, src => src.MapFrom(o => o.Cat_Status)).ReverseMap();


            //SubCategorias
            CreateMap<Dic_SubCategories, SubCategory>()
                .ForMember(x => x.Name, src => src.MapFrom(o => o.Sca_Name))
                .ForMember(x => x.Description, src => src.MapFrom(o => o.Sca_Description))
                .ForMember(x => x.Category, src => src.MapFrom(o => o.Category))
                .ForMember(x => x.CategoryId, src => src.MapFrom(o => o.Sca_CategoryIdFk))
                .ForMember(x => x.CreationUser, src => src.MapFrom(o => o.Sca_CreationUserIdFk))
                .ForMember(x => x.CreationDate, src => src.MapFrom(o => o.Sca_CreationDate))
                .ForMember(x => x.Status, src => src.MapFrom(o => o.Sca_Status));


            //SubCategorias [No contiene Category] Para evitar Queryes mal generadas en entity
            CreateMap<SubCategory, Dic_SubCategories>()
                .ForMember(x => x.Sca_Name, src => src.MapFrom(o => o.Name))
                .ForMember(x => x.Sca_Description, src => src.MapFrom(o => o.Description))
                .ForMember(x => x.Sca_CategoryIdFk, src => src.MapFrom(o => o.CategoryId))
                .ForMember(x => x.Sca_CreationUserIdFk, src => src.MapFrom(o => o.CreationUser))
                .ForMember(x => x.Sca_CreationDate, src => src.MapFrom(o => o.CreationDate))
                .ForMember(x => x.Sca_Status, src => src.MapFrom(o => o.Status));

            //Ciudades
            CreateMap<Dic_Cities, City>()
                .ForMember(x => x.Name, src => src.MapFrom(o => o.Cit_Name)).ReverseMap();
           
            //Usuarios
            CreateMap<Dic_Users, User>()
                .ForMember(x => x.FirstName, src => src.MapFrom(o => o.Use_FirstName))
                .ForMember(x => x.LastName, src => src.MapFrom(o => o.Use_LastName))
                .ForMember(x => x.Money, src => src.MapFrom(o => o.Use_Money))
                .ForMember(x => x.Phone, src => src.MapFrom(o => o.Use_Phone))
                .ForMember(x => x.HashPassword, src => src.MapFrom(o => o.Use_HashPassword))
                .ForMember(x => x.Rol, src => src.MapFrom(o => o.Use_RolIdFk))
                .ForMember(x => x.Status, src => src.MapFrom(o => o.Use_Status))
                .ForMember(x => x.Address, src => src.MapFrom(o => o.Use_Address))
                .ForMember(x => x.CreationDate, src => src.MapFrom(o => o.Use_CreationDate)).ReverseMap();

        }

    }
}
