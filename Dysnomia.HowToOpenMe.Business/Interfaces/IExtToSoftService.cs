using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.Business.Interfaces {
	public interface IExtToSoftService {
		Task<List<ExtToSoft>> GetAll();
	}
}
