using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class AliasService : IAliasService {
		private readonly IAliasDataAccess extensionDataAccess;

		public AliasService(IAliasDataAccess extensionDataAccess) {
			this.extensionDataAccess = extensionDataAccess;
		}

		public async Task<List<Alias>> GetAllAliases() {
			return await extensionDataAccess.GetAllAliases();
		}

		public async Task<Alias> GetAlias(int id) {
			return await extensionDataAccess.GetAlias(id);
		}

		public async Task CreateAlias(Alias alias) {
			await extensionDataAccess.CreateAlias(alias);
		}

		public async Task UpdateAlias(Alias alias) {
			await extensionDataAccess.UpdateAlias(alias);
		}

		public async Task DeleteAlias(int id) {
			await extensionDataAccess.DeleteAlias(id);
		}
	}
}