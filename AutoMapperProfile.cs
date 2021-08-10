using AutoMapper;
using CentralSpecAPI.DTOs;
using CentralSpecAPI.DTOs.ClientVersion;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Models;
using CentralSpecAPI.Models.ClientVersion;
using CentralSpecAPI.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSpecAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Name));
            CreateMap<RoleDtoAdd, Role>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.RoleName)); ;
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<ProductGroup, GetProductGroupDto>();
            CreateMap<Material, GetProductDto>();

            CreateMap<ClientVersion, ClientVersionDtoToAdd>().ReverseMap();
            // .ForMember(x => x.Product, x => x.MapFrom(x => x.Product.ProductGroup));
        }
    }
}