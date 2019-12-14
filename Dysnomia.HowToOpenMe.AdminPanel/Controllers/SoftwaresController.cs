using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class SoftwaresController : Controller {
		private ISoftwareService softwareService;

		public SoftwaresController(ISoftwareService softwareService) {
			this.softwareService = softwareService;
		}

		public async Task<IActionResult> Index() {
			return View(await softwareService.GetAllSoftwares());
		}

		public async Task<IActionResult> Details(string id) {
			return View(await softwareService.GetSoftware(id));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id) {
			return View(await softwareService.GetSoftware(id));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Software software) {
			await softwareService.UpdateSoftware(software);

			return View("Details", await softwareService.GetSoftware(software.SmallName));
		}

		public async Task<IActionResult> Delete(string id) {
			return View(await softwareService.GetSoftware(id));
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePost(string id) {
			await softwareService.DeleteSoftware(id);

			return View("Index", await softwareService.GetAllSoftwares());
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Software software) {
			await softwareService.CreateSoftware(software);

			return View("Details", await softwareService.GetSoftware(software.SmallName));
		}
	}
}