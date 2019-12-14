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
		public int Use { get; set; }
		[Required]
		public int Free { get; set; }
	}
}
