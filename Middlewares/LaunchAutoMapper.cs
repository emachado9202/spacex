using AutoMapper;
using SpaceX.Models;
using SpaceX.Models.Launch;
using System;

namespace SpaceX.Middlewares
{
	public class LaunchAutoMapper: Profile
	{
		public LaunchAutoMapper()
		{
            CreateMap<LaunchModel, LaunchResultModel>()
                .ForMember(dest => dest.Date_Launch,
                           opt => opt.MapFrom(src => src.Launch_Date_Local))
                .ForMember(dest => dest.Rocket_Name,
                           opt => opt.MapFrom(src => src.Rocket.Rocket_Name))
                .ForMember(dest => dest.Rocket_First_Launch,
                           opt => opt.MapFrom(src => src.Rocket.Rocket.First_Flight))
                .ForMember(dest => dest.Rocket_Success_Rate,
                           opt => opt.MapFrom(src => src.Rocket.Rocket.Success_Rate_Pct));
        }
	}
}

