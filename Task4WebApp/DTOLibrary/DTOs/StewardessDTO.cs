using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOLibrary.DTOs
{
    public class StewardessDTO
    {
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }

	}
}
