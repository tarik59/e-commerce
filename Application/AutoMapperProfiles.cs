using Application.Contracts;
using AutoMapper;
using EC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand, BrandDto>(MemberList.Destination);
            CreateMap<BrandDto, Brand>();
            CreateMap<Gender, GenderDto>(MemberList.Destination);
            CreateMap<GenderDto, Gender>();
            CreateMap<TypeOfProduct, TypeOfProductDto>(MemberList.Destination);
            CreateMap<TypeOfProductDto, TypeOfProduct>();
        }
    }
}
