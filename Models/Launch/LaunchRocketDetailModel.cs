using System;
namespace SpaceX.Models.Launch
{
	public class LaunchRocketDetailModel
    {
		public LaunchRocketDetailModel()
		{
		}

        public DateTime First_Flight { get; set; }
        public int Success_Rate_Pct { get; set; }
    }
}

