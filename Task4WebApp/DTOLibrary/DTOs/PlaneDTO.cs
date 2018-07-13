using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class PlaneDTO
    {
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public PlaneTypeDTO TypeOfPlane { get; set; }
		public DateTime ReleaseDate { get; set; }
		public TimeSpan OperationLife { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
