namespace DALProject.Models
{
	public class PlaneType: BaseEntity
	{
		public string Model { get; set; }
		public int Seats { get; set; }
		public int AirLift { get; set; }

	}
}
