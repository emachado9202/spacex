using System;
namespace SpaceX.Models.Launch
{
	public class LaunchRocketModel
	{
		public LaunchRocketModel()
		{
		}

		public string Rocket_Name { get; set; }
		public LaunchRocketDetailModel Rocket { get; set; }
    }
}

