using System;
namespace SpaceX.Models.Launch
{
	public class LaunchResultModel
	{
		public LaunchResultModel()
		{
			Cached_At = DateTime.Now;
		}
		public string Id { get; set; }
		public DateTime Cached_At { get; set; }
		public string Mission_Name { get; set; }
		public DateTime Date_Launch { get; set; }
		public string Rocket_Name { get; set; }
		public DateTime Rocket_First_Launch { get; set; }
		public int Rocket_Success_Rate { get; set; }

	}
}

