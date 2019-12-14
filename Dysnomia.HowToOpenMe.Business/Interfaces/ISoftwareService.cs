using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.Business.Interfaces {
	public interface ISoftwareService {
		Task<List<Software>> GetAllSoftwares();
		Task<Software> GetSoftware(string smallname);
		Task CreateSoftware(Software soft);
		Task UpdateSoftware(Software soft);
		Task DeleteSoftware(string smallname);
	}
}
