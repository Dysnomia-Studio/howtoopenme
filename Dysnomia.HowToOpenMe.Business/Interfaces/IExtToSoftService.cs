using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.Business.Interfaces {
	public interface IExtToSoftService {
		Task<List<ExtToSoft>> GetAll();
		Task<ExtToSoft> Get(string ext, string extName, string software);
		Task Create(ExtToSoft extToSoft);
		Task Delete(string ext, string extName, string software);
	}
}
