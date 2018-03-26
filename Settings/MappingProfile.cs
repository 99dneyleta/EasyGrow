using AutoMapper;
using EasyGrow.DTO;
using EasyGrow.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.Settings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            IQueryable<IdentityRole> roles = null;

            CreateMap<PlantDto, Plant>();
            CreateMap<Plant, PlantDto>();

            CreateMap<ApplicationUserDto, ApplicationUser>();

            CreateMap<TestModel, TestModelDto>();
            CreateMap<TestModelDto, TestModel>();

            CreateMap<GroundwaterLevel, GroundWaterDto>();
            CreateMap<GroundWaterDto, GroundwaterLevel>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(x => x.Role, opt =>
                    opt.MapFrom(src =>
                        src.Id
                            .Join(roles, a => src.Id, b => b.Id, (a, b) => b.Name)
                            .ToList()
                    )
                );
        }
    }
}
