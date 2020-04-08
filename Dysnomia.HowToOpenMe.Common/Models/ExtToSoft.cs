using System.ComponentModel.DataAnnotations;

namespace Dysnomia.HowToOpenMe.Common.Models {
	public class ExtToSoft {
		[Required]
		public string ExtensionId { get; set; }
		[Required]
		public string ExtName { get; set; }
		[Required]
		public string SoftwareId { get; set; }
		[Required]
		public string SoftwareName { get; set; }
		[Required]
		public int Use { get; set; }
		[Required]
		public int Free { get; set; }

		public bool Import { get { return Use >= 4; } }
		public bool Export { get { return (Use >= 2 && Use < 4) || Use >= 6; } }
		public bool Exec { get { return Use % 2 == 1; } }

		[Required]
		public int Windows { get; set; }
		[Required]
		public int MacOS { get; set; }
		[Required]
		public int Linux { get; set; }
		[Required]
		public int Android { get; set; }
		[Required]
		public int Ios { get; set; }
	}
}