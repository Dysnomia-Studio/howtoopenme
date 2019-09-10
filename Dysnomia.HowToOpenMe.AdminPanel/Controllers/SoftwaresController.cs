using Microsoft.AspNetCore.Mvc;
using Dysnomia.HowToOpenMe.Business;
using System.Collections.Generic;
using System.Linq;

using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	public class SoftwaresController : Controller {
		public IActionResult Index() {
			return View(SoftwareDataAccess.GetAllSoftwares());
		}

		public IActionResult Details(string id) {
			return View(SoftwareDataAccess.GetSoftware(id));
		}

		[HttpGet]
		public IActionResult Edit(string id) {
			return View(SoftwareDataAccess.GetSoftware(id));
		}

		[HttpPost]
		public IActionResult Edit(Software software) {
			SoftwareDataAccess.UpdateSoftware(software);

			return View("Details", SoftwareDataAccess.GetSoftware(software.SmallName));
		}

		public IActionResult Delete(string id) {
			return View(SoftwareDataAccess.GetSoftware(id));
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(string id) {
			SoftwareDataAccess.DeleteSoftware(id);

			return View("Index", SoftwareDataAccess.GetAllSoftwares());
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(Software software) {
			SoftwareDataAccess.CreateSoftware(software);

			return View("Details", SoftwareDataAccess.GetSoftware(software.SmallName));
		}
	}
}