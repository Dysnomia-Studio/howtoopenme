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
	}
}
