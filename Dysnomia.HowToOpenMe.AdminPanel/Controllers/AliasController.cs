using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class AliasController : Controller {
		private readonly IAliasService aliasService;

		public AliasController(IAliasService aliasService) {
			this.aliasService = aliasService;
		}

		// GET: Alias
		public async Task<IActionResult> Index() {
			return View(await aliasService.GetAllAliases());
		}

		// GET: Alias/Details/5
		public async Task<IActionResult> Details(int id) {
			return View(await aliasService.GetAlias(id));
		}

		// GET: Alias/Create
		public IActionResult Create() {
			return View();
		}

		// POST: Alias/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Alias alias) {
			await aliasService.CreateAlias(alias);

			return View("Index", await aliasService.GetAllAliases());
		}

		// GET: Alias/Edit/5
		public async Task<IActionResult> Edit(int id) {
			return View(await aliasService.GetAlias(id));
		}

		// POST: Alias/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Alias alias) {
			await aliasService.UpdateAlias(alias);

			return View("Details", await aliasService.GetAlias(alias.Id));
		}

		// GET: Alias/Delete/5
		public async Task<IActionResult> Delete(int id) {
			return View(await aliasService.GetAlias(id));
		}

		// POST: Alias/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeletePost(int id) {
			await aliasService.DeleteAlias(id);

			return View("Index", await aliasService.GetAllAliases());
		}
	}
}