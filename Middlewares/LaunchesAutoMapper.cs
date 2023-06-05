using AutoMapper;
using SpaceX.Models;
using System;

namespace SpaceX.Middlewares
{
	public class LaunchesAutoMapper: Profile
	{
		public LaunchesAutoMapper()
		{
            CreateMap<LaunchModel, LaunchResultModel>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Mission_Name));
            CreateMap<LaunchResultModel, LaunchModel>();
        }
	}
}

