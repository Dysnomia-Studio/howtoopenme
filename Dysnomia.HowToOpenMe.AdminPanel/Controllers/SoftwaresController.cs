using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class SoftwaresController : Controller {
		public async Task<IActionResult> Index() {
			return View(await SoftwareDataAccess.GetAllSoftwares());
		}

		public async Task<IActionResult> Details(string id) {
			return View(await SoftwareDataAccess.GetSoftware(id));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id) {
			return View(await SoftwareDataAccess.GetSoftware(id));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Software software) {
			await SoftwareDataAccess.UpdateSoftware(software);

			return View("Details", await SoftwareDataAccess.GetSoftware(software.SmallName));
		}

		public async Task<IActionResult> Delete(string id) {
			return View(await SoftwareDataAccess.GetSoftware(id));
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePost(string id) {
			await SoftwareDataAccess.DeleteSoftware(id);

			return View("Index", await SoftwareDataAccess.GetAllSoftwares());
		}

		public async Task<IActionResult> Create() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Software software) {
			await SoftwareDataAccess.CreateSoftware(software);

			return View("Details", await SoftwareDataAccess.GetSoftware(software.SmallName));
		}
	}
}