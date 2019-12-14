using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.Business.Interfaces {
	public interface IExtensionService {
		Task<List<Extension>> GetAllExtensions();
		Task<Extension> GetExtension(string ext);
		Task CreateExtension(Extension ext);
		Task UpdateExtension(Extension ext);
		Task DeleteExtension(string ext);
	}
}
