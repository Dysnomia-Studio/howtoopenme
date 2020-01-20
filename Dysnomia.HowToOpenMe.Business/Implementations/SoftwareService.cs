using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class SoftwareService : ISoftwareService {
		private readonly ISoftwareDataAccess softwareDataAccess;

		public SoftwareService(ISoftwareDataAccess softwareDataAccess) {
			this.softwareDataAccess = softwareDataAccess;
		}

		public async Task<List<Software>> GetAllSoftwares() {
			return await softwareDataAccess.GetAllSoftwares();
		}

		public async Task<Software> GetSoftware(string smallname) {
			return await softwareDataAccess.GetSoftware(smallname);
		}

		public async Task CreateSoftware(Software soft) {
			await softwareDataAccess.CreateSoftware(soft);
		}

		public async Task UpdateSoftware(Software soft) {
			await softwareDataAccess.UpdateSoftware(soft);
		}

		public async Task DeleteSoftware(string smallname) {
			await softwareDataAccess.DeleteSoftware(smallname);
		}
	}
}
