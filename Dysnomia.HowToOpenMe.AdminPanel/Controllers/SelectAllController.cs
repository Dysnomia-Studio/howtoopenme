using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dysnomia.HowToOpenMe.AdminPanel.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class SelectAllController : ControllerBase {
		private readonly IExtensionService extensionService;
		private readonly ISoftwareService softwareService;

		public SelectAllController(IExtensionService extensionService, ISoftwareService softwareService) {
			this.extensionService = extensionService;
			this.softwareService = softwareService;
		}

		[HttpGet("extension")]
		public async Task<ActionResult<IEnumerable<Extension>>> GetAllExtensions() {
			var result = await extensionService.GetAllExtensions();

			if (!result.Any()) {
				return NoContent();
			}

			return Ok(result);
		}

		[HttpGet("software")]
		public async Task<ActionResult<IEnumerable<Software>>> GetAllSoftwares() {
			var result = await softwareService.GetAllSoftwares();

			if (!result.Any()) {
				return NoContent();
			}

			return Ok(result);
		}
	}
}