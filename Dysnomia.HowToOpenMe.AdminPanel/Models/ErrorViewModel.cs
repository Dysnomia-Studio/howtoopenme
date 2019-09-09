using System;

namespace Dysnomia.HowToOpenMe.AdminPanel.Models {
	public class ErrorViewModel {
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}