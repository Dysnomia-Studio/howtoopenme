using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dysnomia.HowToOpenMe.Business.Interfaces {
	public interface ISearchService {
		Task<IDictionary<string, string>> Search(string searchText);
	}
}
