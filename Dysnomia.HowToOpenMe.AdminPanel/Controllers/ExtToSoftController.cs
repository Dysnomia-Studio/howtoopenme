using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtToSoftController : Controller {
		public async Task<IActionResult> Index() {
			return View(await ExtToSoftDataAccess.GetAll());
		}
	}
}
