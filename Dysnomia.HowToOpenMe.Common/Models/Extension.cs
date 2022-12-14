using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dysnomia.HowToOpenMe.Common.Models {
	public class Extension {
		[Required]
		public string Ext { get; set; }
		[Required]
		public string Name { get; set; }
		public string Desc { get; set; }
		public string MIMEType { get; set; }

		public List<string> Alias { get; set; }
		public List<ExtToSoft> ExtToSoft { get; set; }
	}
}
