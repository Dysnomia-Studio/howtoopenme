using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class ExtensionService : IExtensionService {
		private readonly IExtensionDataAccess extensionDataAccess;

		public ExtensionService(IExtensionDataAccess extensionDataAccess) {
			this.extensionDataAccess = extensionDataAccess;
		}

		public async Task<List<Extension>> GetAllExtensions() {
			try {
				return await extensionDataAccess.GetAllExtensions();
			} catch (Exception e) {
				// @TODO: log it
			}

			return null;
		}

		public async Task<Extension> GetExtension(string ext) {
			try {
				return await extensionDataAccess.GetExtension(ext);
			} catch (Exception e) {
				// @TODO: log it
			}

			return null;
		}

		public async Task CreateExtension(Extension ext) {
			try {
				await extensionDataAccess.CreateExtension(ext);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task UpdateExtension(Extension ext) {
			try {
				await extensionDataAccess.UpdateExtension(ext);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task DeleteExtension(string ext) {
			try {
				await extensionDataAccess.DeleteExtension(ext);
			} catch (Exception e) {
				// @TODO: log it
			}
		}

		public async Task<List<Extension>> GetTopExtensions() {
			try {
				return await extensionDataAccess.GetTopExtensions();
			} catch (Exception e) {
				// @TODO: log it
			}

			return new List<Extension>();
		}

		public async Task AddView(string name) {
			try {
				await extensionDataAccess.AddView(name);
			} catch (Exception e) {
				// @TODO: log it
			}
		}
	}
}
