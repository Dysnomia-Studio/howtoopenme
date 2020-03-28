using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.DataAccess.Interfaces {
	public interface IExtensionDataAccess {
		Task<List<Extension>> GetAllExtensions();
		Task<Extension> GetExtension(string ext);
		Task CreateExtension(Extension ext);
		Task UpdateExtension(Extension ext);
		Task DeleteExtension(string ext);

		Task<List<Extension>> GetTopExtensions();
		Task AddView(string name);

		Task<List<Extension>> Search(string searchText);
	}
}
