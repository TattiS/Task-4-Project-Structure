using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class CrewDTO
    {
		public int Id { get; set; }
		public int PilotId { get; set; }
		public List<int> StewardessesId { get; set; }

	}
}
