using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dysnomia.HowToOpenMe.Common.Models {
	public class Software {
		[Required]
		public string SmallName { get; set; }
		[Required]
		public string Name { get; set; }

		public string Desc { get; set; }
		public string URL { get; set; }

		public int Windows { get; set; }
		public int MacOS { get; set; }
		public int Linux { get; set; }
		public int Android { get; set; }
		public int IOS { get; set; }

		public List<ExtToSoft> ExtToSoft { get; set; }
	}
}

