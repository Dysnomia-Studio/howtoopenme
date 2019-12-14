using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtToSoftController : Controller {
		private IExtToSoftService extToSoftService;

		public ExtToSoftController(IExtToSoftService extToSoftService) {
			this.extToSoftService = extToSoftService;
		}

		public async Task<IActionResult> Index() {
			return View(await extToSoftService.GetAll());
		}
	}
}
