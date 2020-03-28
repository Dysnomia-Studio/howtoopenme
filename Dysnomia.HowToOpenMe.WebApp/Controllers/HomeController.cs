using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Dysnomia.Common.Security;
using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.WebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.WebApp.Controllers {
	public class HomeController : Controller {
		private readonly IExtensionService extensionService;
		private readonly ISoftwareService softwareService;
		private readonly ISearchService searchService;

		public HomeController(IExtensionService extensionService, ISoftwareService softwareService, ISearchService searchService) {
			this.extensionService = extensionService;
			this.softwareService = softwareService;
			this.searchService = searchService;
		}

		[HttpGet]
		[Route("/")]
		[Route("{culture}/")]
		[Route("index")]
		[Route("{culture}/index")]
		public async Task<IActionResult> Index() {
			BotHelper.SetSessionsVars(HttpContext);

			ViewData["TopExt"] = await extensionService.GetTopExtensions();
			ViewData["TopSoft"] = await softwareService.GetTopSoftwares();

			return View("Index");
		}

		[HttpGet]
		[Route("/search/{searchText}")]
		[Route("{culture}/search/{searchText}")]
		public async Task<IActionResult> Search(string searchText) {
			IDictionary<string, string> result = null;
			ViewData["SearchText"] = searchText;
			if (!BotHelper.IsBot(HttpContext) && !string.IsNullOrWhiteSpace(searchText)) {
				result = await searchService.Search(searchText);
			}

			BotHelper.SetSessionsVars(HttpContext);

			if (result == null) {
				return await Index();
			}

			if (!result.Any()) {
				ViewData["error"] = "Erreur: Aucun resultat";
				return await Index();
			}

			ViewData["Results"] = result;

			return View();
		}

		[HttpGet]
		[Route("/ext/{searchText}")]
		[Route("{culture}/ext/{searchText}")]
		public async Task<IActionResult> Ext(string name) {
			var result = await extensionService.GetExtension(name);
			ViewData["Result"] = result;

			if (ViewData["Result"] == null) {
				ViewData["error"] = "Erreur: Page inexistante";
				return await Index();
			}

			await extensionService.AddView(result.Name);

			return View();
		}

		[HttpGet]
		[Route("/soft/{searchText}")]
		[Route("{culture}/soft/{searchText}")]
		public async Task<IActionResult> Soft(string name) {
			var result = await softwareService.GetSoftware(name);
			ViewData["Result"] = result;

			if (ViewData["Result"] == null) {
				ViewData["error"] = "Erreur: Page inexistante";
				return await Index();
			}

			await softwareService.AddView(result.Name);

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
