using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class SearchService : ISearchService {
		private readonly ISoftwareDataAccess softwareDataAccess;
		private readonly IExtensionDataAccess extensionDataAccess;

		public SearchService(ISoftwareDataAccess softwareDataAccess, IExtensionDataAccess extensionDataAccess) {
			this.softwareDataAccess = softwareDataAccess;
			this.extensionDataAccess = extensionDataAccess;
		}

		public async Task<IDictionary<string, string>> Search(string searchText) {
			try {
				Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

				var extensions = await extensionDataAccess.Search(searchText);
				var softwares = await softwareDataAccess.Search(searchText);

				foreach (var extension in extensions) {
					keyValuePairs.Add("ext/" + extension.Ext, extension.Ext + " (" + extension.Name + ")");
				}
				foreach (var software in softwares) {
					keyValuePairs.Add("soft/" + software.SmallName, software.SmallName + " (" + software.Name + ")");
				}

				return keyValuePairs;
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			return null;
		}
	}
}
