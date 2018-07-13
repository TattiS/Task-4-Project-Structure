using System;
using System.Collections.Generic;
using System.Text;

namespace DALProject.Models
{
    public class Departure: BaseEntity
	{
		public int FlightId { get; set; }
		public DateTime DepartureDate { get; set; }
		public Crew CrewItem { get; set; }
		public Plane PlaneItem { get; set; }

	}
}
