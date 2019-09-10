using Microsoft.AspNetCore.Mvc;
using Dysnomia.HowToOpenMe.Business;
using System.Collections.Generic;
using System.Linq;

using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class ExtensionsController : Controller {
		public IActionResult Index() {
			return View(ExtensionDataAccess.GetAllExtensions());
		}

		public IActionResult Details(string id) {
			return View(ExtensionDataAccess.GetExtension(id));
		}

		[HttpGet]
		public IActionResult Edit(string id) {
			return View(ExtensionDataAccess.GetExtension(id));
		}

		[HttpPost]
		public IActionResult Edit(Extension extension) {
			ExtensionDataAccess.UpdateExtension(extension);

			return View("Details", ExtensionDataAccess.GetExtension(extension.Ext));
		}

		public IActionResult Delete(string id) {
			return View(ExtensionDataAccess.GetExtension(id));
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(string id) {
			ExtensionDataAccess.DeleteExtension(id);

			return View("Index", ExtensionDataAccess.GetAllExtensions());
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(Extension extension) {
			ExtensionDataAccess.CreateExtension(extension);

			return View("Details", ExtensionDataAccess.GetExtension(extension.Ext));
		}
	}
}