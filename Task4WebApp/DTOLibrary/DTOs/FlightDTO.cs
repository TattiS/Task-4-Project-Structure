using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class FlightDTO
    {
		public int Id { get; set; }
		[Required]
		public string DeparturePoint { get; set; }
		[Required]
		public DateTime DepartureTime { get; set; }
		[Required]
		public string Destination { get; set; }
		[Required]
		public DateTime ArrivalTime { get; set; }
		public IEnumerable<TicketDTO> Tickets { get; set; }

	}
}
