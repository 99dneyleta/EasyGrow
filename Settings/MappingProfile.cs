using AutoMapper;
using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
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

            // GroundWater

            CreateMap<GroundwaterLevel, GroundWaterDto>();
            CreateMap<GroundWaterDto, GroundwaterLevel>();
            CreateMap<GroundWaterDto, GroundWaterPostDto>();
            CreateMap<GroundWaterPostDto, GroundWaterDto>();
            CreateMap<GroundwaterLevel, GroundWaterPostDto>();
            CreateMap<GroundWaterPostDto, GroundwaterLevel>();

            // AdditionalCriteries

            CreateMap<AdditionalCriteries, AdditionalCriteriesDto>()
                .ForPath(dest=>dest.GroundwaterLevel.GroundwaterLevelId,opt => opt.MapFrom(src => src.GroundwaterLevelId));
            CreateMap<AdditionalCriteriesDto, AdditionalCriteries>();
            CreateMap<AdditionalCriteriesDto, AdditionalCriteriesPostDto>();
            CreateMap<AdditionalCriteriesPostDto, AdditionalCriteriesDto>();
            CreateMap<AdditionalCriteries, AdditionalCriteriesPostDto>();
            CreateMap<AdditionalCriteriesPostDto, AdditionalCriteries>();




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
