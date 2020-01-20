using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class ExtToSoftService : IExtToSoftService {
		private readonly IExtToSoftDataAccess extToSoftDataAccess;

		public ExtToSoftService(IExtToSoftDataAccess extToSoftDataAccess) {
			this.extToSoftDataAccess = extToSoftDataAccess;
		}
		public async Task<List<ExtToSoft>> GetAll() {
			return await extToSoftDataAccess.GetAll();
		}
		public async Task<ExtToSoft> Get(string ext, string extName, string software) {
			return await extToSoftDataAccess.Get(ext, extName, software);
		}
		public async Task Create(ExtToSoft extToSoft) {
			await extToSoftDataAccess.Create(extToSoft);
		}
		public async Task Delete(string ext, string extName, string software) {
			await extToSoftDataAccess.Delete(ext, extName, software);
		}
	}
}
