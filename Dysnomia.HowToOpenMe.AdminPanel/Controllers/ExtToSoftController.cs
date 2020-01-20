using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtToSoftController : Controller {
		private readonly IExtToSoftService extToSoftService;
		private readonly IExtensionService extensionService;
		private readonly ISoftwareService softwareService;

		public ExtToSoftController(IExtToSoftService extToSoftService, IExtensionService extensionService, ISoftwareService softwareService) {
			this.extToSoftService = extToSoftService;
			this.extensionService = extensionService;
			this.softwareService = softwareService;
		}


		// GET: ExtToSoft
		public async Task<IActionResult> Index() {
			return View("Index", await extToSoftService.GetAll());
		}

		// GET: ExtToSoft/Details/5
		public async Task<IActionResult> Details(string ext, string extName, string software) {
			return View(await extToSoftService.Get(ext, extName, software));
		}

		// GET: ExtToSoft/Create
		public async Task<IActionResult> Create() {
			@ViewData["extensions"] = new SelectList(
				await extensionService.GetAllExtensions(),
				nameof(Extension.Ext), nameof(Extension.Ext)
			);

			@ViewData["extensionsName"] = new SelectList(
				await extensionService.GetAllExtensions(),
				nameof(Extension.Name), nameof(Extension.Name)
			);

			@ViewData["softwares"] = new SelectList(
				await softwareService.GetAllSoftwares(),
				nameof(Software.SmallName), nameof(Software.Name)
			);

			return View();
		}

		// POST: ExtToSoft/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExtToSoft extToSoft) {
			await extToSoftService.Create(extToSoft);

			return await Index();
		}

		// GET: ExtToSoft/Delete/5
		public async Task<IActionResult> Delete(string ext, string extName, string software) {
			return View(await extToSoftService.Get(ext, extName, software));
		}

		// POST: ExtToSoft/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeletePost(string ext, string extName, string software) {
			await extToSoftService.Delete(ext, extName, software);

			return await Index();
		}
	}
}
