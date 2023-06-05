using AutoMapper;
using SpaceX.Models;
using System;

namespace SpaceX.Middlewares
{
	public class LaunchesAutoMapper: Profile
	{
		public LaunchesAutoMapper()
		{
            CreateMap<LaunchesModel, LaunchesResultModel>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Mission_Name));
        }
	}
}

