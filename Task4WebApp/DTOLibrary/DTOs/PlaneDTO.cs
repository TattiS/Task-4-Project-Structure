using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class PlaneDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public PlaneTypeDTO TypeOfPlane { get; set; }
		public DateTime ReleaseDate { get; set; }
		public TimeSpan OperationLife { get; set; }

	}
}
