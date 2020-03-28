using System;
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
			try {
				return await softwareDataAccess.GetAllSoftwares();
			} catch (Exception e) {
				// @TODO: log it
			}

			return null;
		}

		public async Task<Software> GetSoftware(string smallname) {
			try {
				return await softwareDataAccess.GetSoftware(smallname);
			} catch (Exception e) {
				// @TODO: log it
			}

			return null;
		}

		public async Task CreateSoftware(Software soft) {
			try {
				await softwareDataAccess.CreateSoftware(soft);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task UpdateSoftware(Software soft) {
			try {
				await softwareDataAccess.UpdateSoftware(soft);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task DeleteSoftware(string smallname) {
			try {
				await softwareDataAccess.DeleteSoftware(smallname);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task<List<Software>> GetTopSoftwares() {
			try {
				return await softwareDataAccess.GetTopSoftwares();
			} catch (Exception e) {
				// @TODO: log it
			}

			return new List<Software>();
		}

		public async Task AddView(string name) {
			try {
				await softwareDataAccess.AddView(name);
			} catch (Exception e) {
				// @TODO: log it
			}
		}
	}
}
