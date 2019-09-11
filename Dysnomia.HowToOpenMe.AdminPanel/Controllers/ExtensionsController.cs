using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtensionsController : Controller {
		public async Task<IActionResult> Index() {
			return View(await ExtensionDataAccess.GetAllExtensions());
		}

		public async Task<IActionResult> Details(string id) {
			return View(await ExtensionDataAccess.GetExtension(id));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id) {
			return View(await ExtensionDataAccess.GetExtension(id));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Extension extension) {
			await ExtensionDataAccess.UpdateExtension(extension);

			return View("Details", await ExtensionDataAccess.GetExtension(extension.Ext));
		}

		public async Task<IActionResult> Delete(string id) {
			return View(await ExtensionDataAccess.GetExtension(id));
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePost(string id) {
			await ExtensionDataAccess.DeleteExtension(id);

			return View("Index", await ExtensionDataAccess.GetAllExtensions());
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Extension extension) {
			await ExtensionDataAccess.CreateExtension(extension);

			return View("Details", await ExtensionDataAccess.GetExtension(extension.Ext));
		}
	}
}