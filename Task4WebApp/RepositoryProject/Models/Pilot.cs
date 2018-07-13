using System;

namespace DALProject.Models
{
	public class Pilot: BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
		public TimeSpan Experience { get; set; }

	}
}
