using System.Collections.Generic;

namespace DALProject.Models
{
	public class Crew:BaseEntity
    {
		public int PilotId { get; set; }
		public List<int> StewardessesId { get; set; }

	}
}
