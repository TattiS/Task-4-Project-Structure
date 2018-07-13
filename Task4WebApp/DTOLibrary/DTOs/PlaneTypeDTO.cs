using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class PlaneTypeDTO
    {
		public int Id { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public int Seats { get; set; }
		[Required]
		public int AirLift { get; set; }

	}
}
