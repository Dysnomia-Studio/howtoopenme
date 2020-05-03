using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Business.Interfaces;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

namespace Dysnomia.HowToOpenMe.Business.Implementations {
	public class ExtensionService : IExtensionService {
		private readonly IExtensionDataAccess extensionDataAccess;
		private readonly IAliasDataAccess aliasDataAccess;
		private readonly IExtToSoftDataAccess extToSoftDataAccess;

		public ExtensionService(IExtensionDataAccess extensionDataAccess, IAliasDataAccess aliasDataAccess, IExtToSoftDataAccess extToSoftDataAccess) {
			this.extensionDataAccess = extensionDataAccess;
			this.aliasDataAccess = aliasDataAccess;
			this.extToSoftDataAccess = extToSoftDataAccess;
		}

		public async Task<List<Extension>> GetAllExtensions() {
			try {
				return await extensionDataAccess.GetAllExtensions();
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			return null;
		}

		public async Task<Extension> GetExtension(string ext) {
			try {
				var extension = await extensionDataAccess.GetExtension(ext);

				if (extension == null) {
					return null;
				}

				extension.Alias = (await aliasDataAccess.GetAllAliases())
					.Where((Alias alias) => alias.Ext == extension.Ext && alias.ExtName == extension.Name)
					.Select((elt) => "." + elt.ExtName)
					.ToList();
				extension.ExtToSoft = (await extToSoftDataAccess.GetAll())
					.Where((ExtToSoft extToSoft) => extToSoft.ExtensionId == extension.Ext && extToSoft.ExtName == extension.Name)
					.ToList();

				return extension;
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			return null;
		}

		public async Task CreateExtension(Extension ext) {
			try {
				await extensionDataAccess.CreateExtension(ext);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}

		public async Task UpdateExtension(Extension ext) {
			try {
				await extensionDataAccess.UpdateExtension(ext);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}

		public async Task DeleteExtension(string ext) {
			try {
				await extensionDataAccess.DeleteExtension(ext);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}

		public async Task<List<Extension>> GetTopExtensions() {
			try {
				return await extensionDataAccess.GetTopExtensions();
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			return new List<Extension>();
		}

		public async Task AddView(string name) {
			try {
				await extensionDataAccess.AddView(name);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}
	}
}
