using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class PilotDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
		public TimeSpan Experience { get; set; }
		public DateTime StartedIn { get; set; }
	}
}
