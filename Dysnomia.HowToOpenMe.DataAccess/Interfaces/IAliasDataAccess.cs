using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.DataAccess.Interfaces {
	public interface IAliasDataAccess {
		Task<List<Alias>> GetAllAliases();
		Task<Alias> GetAlias(int id);
		Task CreateAlias(Alias alias);
		Task UpdateAlias(Alias alias);
		Task DeleteAlias(int id);
	}
}
