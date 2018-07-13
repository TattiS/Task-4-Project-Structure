using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class FlightDTO
    {
		public int Id { get; set; }
		public string DeparturePoint { get; set; }
		public DateTime DepartureTime { get; set; }
		public string Destination { get; set; }
		public DateTime ArrivalTime { get; set; }
		public IEnumerable<TicketDTO> Tickets { get; set; }

	}
}
