using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpaceX.Models
{
	public class LaunchPaginationModel
	{
		public LaunchPaginationModel()
		{
			Page = 1;
			Per_Page = 10;
		}

        [Range(1, int.MaxValue, ErrorMessage = "Not valid Number. Enter a value bigger than {1}")]
        public int Page { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Not valid Number. Enter a value bigger than {1}")]
        public int Per_Page { get; set; }
	}
}

