using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.DataAccess.Interfaces {
	public interface ISoftwareDataAccess {
		Task<List<Software>> GetAllSoftwares();
		Task<Software> GetSoftware(string smallname);
		Task CreateSoftware(Software soft);
		Task UpdateSoftware(Software soft);
		Task DeleteSoftware(string smallname);
	}
}
