using System;
using System.Collections.Generic;

namespace DALProject.Models
{
	public class Flight: BaseEntity
	{
		public string DeparturePoint { get; set; }
		public DateTime DepartureTime { get; set; }
		public string Destination { get; set; }
		public DateTime ArrivalTime { get; set; }
		public List<Ticket> Tickets { get; set; }

	}
}
