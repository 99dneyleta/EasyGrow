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

            // Class

            CreateMap<Class, ClassDto>();
            CreateMap<ClassDto, Class>();
            CreateMap<ClassDto, ClassPostDto>();
            CreateMap<ClassPostDto, ClassDto>();
            CreateMap<Class, ClassPostDto>();
            CreateMap<ClassPostDto, Class>();

            // Geolocation

            CreateMap<Geolocation, GeolocationDto>();
            CreateMap<GeolocationDto, Geolocation>();
            CreateMap<GeolocationDto, GeolocationPostDto>();
            CreateMap<GeolocationPostDto, GeolocationDto>();
            CreateMap<Geolocation, GeolocationPostDto>();
            CreateMap<GeolocationPostDto, Geolocation>();

            // Phase

            CreateMap<Phase, PhaseDto>();
            CreateMap<PhaseDto, Phase>();
            CreateMap<PhaseDto, PhasePostDto>();
            CreateMap<PhasePostDto, PhaseDto>();
            CreateMap<Phase, PhasePostDto>();
            CreateMap<PhasePostDto, Phase>();

            // Plant
            CreateMap<PlantDto, PlantPostDto>();
            CreateMap<PlantPostDto, PlantDto>();
            CreateMap<Plant, PlantPostDto>();
            CreateMap<PlantPostDto, Plant>();




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
