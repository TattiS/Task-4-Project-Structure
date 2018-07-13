using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class DepartureDTO
    {
		public int Id { get; set; }
		[Required]
		public int FlightId { get; set; }
		[Required]
		public DateTime DepartureDate { get; set; }
		public CrewDTO CrewItem { get; set; }
		public PlaneDTO PlaneItem { get; set; }

	}
}
