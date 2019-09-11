using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Dysnomia.HowToOpenMe.Common;
using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.Business {
	public class ExtensionDataAccess {
		public static string connectionString = "***REMOVED***";

		public static Extension MapFromReader(IDataReader reader) {
			var ext = new Extension() {
				Ext = SQLHelper.GetStringFromReader(reader, "ext"),
				Name = SQLHelper.GetStringFromReader(reader, "name"),
				Desc = SQLHelper.GetStringFromReader(reader, "desc"),
				MIMEType = SQLHelper.GetStringFromReader(reader, "MIMEType"),
			};

			return ext;
		}

		public static Extension MapFromBlankReader(IDataReader reader) {
			reader.Read();

			return MapFromReader(reader);
		}

		public static List<Extension> MapListFromReader(IDataReader reader) {
			List<Extension> extensions = new List<Extension>();

			while (reader.Read()) {
				extensions.Add(MapFromReader(reader));
			}

			extensions.Sort((a, b) => {
				return a.Ext.CompareTo(b.Ext);
			});

			return extensions;
		}

		public static async Task<List<Extension>> GetAllExtensions() {
			using (var connection = new NpgsqlConnection(connectionString)) {
				return MapListFromReader(await SQLHelper.ExecSelect(connection, "SELECT * FROM extensions"));
			}
		}

		public static async Task<Extension> GetExtension(string ext) {
			using (var connection = new NpgsqlConnection(connectionString)) {
				return MapFromBlankReader(await SQLHelper.ExecSelect(connection, "SELECT * FROM extensions WHERE ext = @extension", new Dictionary<string, object>() {
					{ "extension", ext }
				}));
			}
		}

		public static async Task CreateExtension(Extension ext) {
			using (var connection = new NpgsqlConnection(connectionString)) {
				await SQLHelper.Exec(connection, "INSERT INTO public.extensions(ext, name, \"desc\", \"MIMEType\") VALUES(@ext, @name, @description, @MIMEType)", new Dictionary<string, object>() {
					{ "ext", ext.Ext },
					{ "name", ext.Name },
					{ "description", ext.Desc ?? "" },
					{ "MIMEType", ext.MIMEType ?? "" }
				});
			}
		}

		public static async Task UpdateExtension(Extension ext) {
			using (var connection = new NpgsqlConnection(connectionString)) {
				await SQLHelper.Exec(connection, "UPDATE public.extensions SET name=@name, \"desc\"=@description, \"MIMEType\"=@MIMEType WHERE ext=@extension", new Dictionary<string, object>() {
					{ "extension", ext.Ext },
					{ "name", ext.Name },
					{ "description", ext.Desc ?? "" },
					{ "MIMEType", ext.MIMEType ?? "" }
				});
			}
		}

		public static async Task DeleteExtension(string ext) {
			using (var connection = new NpgsqlConnection(connectionString)) {
				await SQLHelper.Exec(connection, "DELETE FROM public.extensions WHERE ext=@extension", new Dictionary<string, object>() {
					{ "extension", ext }
				});
			}
		}
	}
}
