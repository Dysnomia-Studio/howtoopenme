using System.Diagnostics;

using Dysnomia.HowToOpenMe.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.WebApp.Controllers {
	public class HomeController : Controller {
		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
