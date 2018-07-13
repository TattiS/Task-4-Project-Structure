using System;

namespace DALProject.Models
{
	public class Stewardess: BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
