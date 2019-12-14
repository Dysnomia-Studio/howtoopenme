using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtensionsController : Controller {
		private IExtensionService extensionService;

		public ExtensionsController(IExtensionService extensionService) {
			this.extensionService = extensionService;
		}

		public async Task<IActionResult> Index() {
			return View(await extensionService.GetAllExtensions());
		}

		public async Task<IActionResult> Details(string id) {
			return View(await extensionService.GetExtension(id));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id) {
			return View(await extensionService.GetExtension(id));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Extension extension) {
			await extensionService.UpdateExtension(extension);

			return View("Details", await extensionService.GetExtension(extension.Ext));
		}

		public async Task<IActionResult> Delete(string id) {
			return View(await extensionService.GetExtension(id));
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePost(string id) {
			await extensionService.DeleteExtension(id);

			return View("Index", await extensionService.GetAllExtensions());
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Extension extension) {
			await extensionService.CreateExtension(extension);

			return View("Details", await ExtensionDataAccess.GetExtension(extension.Ext));
		}
	}
}