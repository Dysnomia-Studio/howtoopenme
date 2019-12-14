using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dysnomia.Common.SQL;
using Dysnomia.HowToOpenMe.Common;
using Dysnomia.HowToOpenMe.Common.Models;
using Dysnomia.HowToOpenMe.DataAccess.Interfaces;

using Microsoft.Extensions.Options;

using Npgsql;

namespace Dysnomia.HowToOpenMe.DataAccess.Implementations {
	public class ExtensionDataAccess : IExtensionDataAccess {
		private readonly string connectionString;

		public ExtensionDataAccess(IOptions<AppSettings> appSettings) {
			connectionString = appSettings.Value.ConnectionString;
		}

		public Extension MapFromReader(IDataReader reader) {

			var ext = new Extension {
				Ext = reader.GetString("ext"),
				Name = reader.GetString("name"),
				Desc = reader.GetString("desc"),
				MIMEType = reader.GetString("MIMEType"),
			};

			return ext;
		}

		public Extension MapFromBlankReader(IDataReader reader) {
			reader.Read();

			return MapFromReader(reader);
		}

		public List<Extension> MapListFromReader(IDataReader reader) {
			List<Extension> extensions = new List<Extension>();

			while (reader.Read()) {
				extensions.Add(MapFromReader(reader));
			}

			extensions.Sort((a, b) => {
				return a.Ext.CompareTo(b.Ext);
			});

			return extensions;
		}

		public async Task<List<Extension>> GetAllExtensions() {
			using var connection = new NpgsqlConnection(connectionString);

			return MapListFromReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM extensions"));
		}

		public async Task<Extension> GetExtension(string ext) {
			using var connection = new NpgsqlConnection(connectionString);

			return MapFromBlankReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM extensions WHERE ext = @extension", new Dictionary<string, object>() {
				{ "extension", ext }
			}));
		}

		public async Task CreateExtension(Extension ext) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "INSERT INTO public.extensions(ext, name, \"desc\", \"MIMEType\") VALUES(@ext, @name, @description, @MIMEType)", new Dictionary<string, object>() {
				{ "ext", ext.Ext },
				{ "name", ext.Name },
				{ "description", ext.Desc ?? "" },
				{ "MIMEType", ext.MIMEType ?? "" }
			});
		}

		public async Task UpdateExtension(Extension ext) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "UPDATE public.extensions SET name=@name, \"desc\"=@description, \"MIMEType\"=@MIMEType WHERE ext=@extension", new Dictionary<string, object>() {
				{ "extension", ext.Ext },
				{ "name", ext.Name },
				{ "description", ext.Desc ?? "" },
				{ "MIMEType", ext.MIMEType ?? "" }
			});
		}

		public async Task DeleteExtension(string ext) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "DELETE FROM public.extensions WHERE ext=@extension", new Dictionary<string, object>() {
				{ "extension", ext }
			});
		}
	}
}
