using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common.Models;

namespace Dysnomia.HowToOpenMe.DataAccess.Interfaces {
	public interface IExtToSoftDataAccess {
		Task<List<ExtToSoft>> GetAll();
	}
}
