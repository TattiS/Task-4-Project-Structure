using System;

namespace DALProject.Models
{
	public class Plane: BaseEntity
	{
		public string Name { get; set; }
		public PlaneType TypeOfPlane { get; set; }
		public DateTime ReleaseDate { get; set; }
		public TimeSpan OperationLife { get; set; }

	}
}
