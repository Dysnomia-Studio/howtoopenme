using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class ExtensionService : IExtensionService {
		private readonly IExtensionDataAccess extensionDataAccess;

		public ExtensionService(IExtensionDataAccess extensionDataAccess) {
			this.extensionDataAccess = extensionDataAccess;
		}

		public async Task<List<Extension>> GetAllExtensions() {
			return await extensionDataAccess.GetAllExtensions();
		}

		public async Task<Extension> GetExtension(string ext) {
			return await extensionDataAccess.GetExtension(ext);
		}

		public async Task CreateExtension(Extension ext) {
			await extensionDataAccess.CreateExtension(ext);
		}

		public async Task UpdateExtension(Extension ext) {
			await extensionDataAccess.UpdateExtension(ext);
		}

		public async Task DeleteExtension(string ext) {
			await extensionDataAccess.DeleteExtension(ext);
		}
	}
}
