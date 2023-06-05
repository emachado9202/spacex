using System;
namespace SpaceX.Models.Launch
{
	public class LaunchModel
	{
		public LaunchModel()
		{
		}

		public string Id { get; set; }
		public string Mission_Name { get; set; }
        public DateTime Launch_Date_Local { get; set; }
		public LaunchRocketModel Rocket { get; set; }
	}
}

