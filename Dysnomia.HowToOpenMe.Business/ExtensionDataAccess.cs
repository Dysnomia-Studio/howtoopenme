using System.Collections.Generic;
using System.Linq;

using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.Business
{
    public class ExtensionDataAccess {
		public static Extension MapFromReader(NpgsqlDataReader reader) {
			var ext = new Extension() {
				Ext = reader.GetString(reader.GetOrdinal("ext")),
				Name = reader.GetString(reader.GetOrdinal("name")),
			};

			if (!reader.IsDBNull(reader.GetOrdinal("desc"))) {
				ext.Desc = reader.GetString(reader.GetOrdinal("desc"));
			}

			if (!reader.IsDBNull(reader.GetOrdinal("MIMEType"))) {
				ext.MIMEType = reader.GetString(reader.GetOrdinal("MIMEType"));
			}

			return ext;
		}

		public static List<Extension> MapListFromReader(NpgsqlDataReader reader) {
			List<Extension> extensions = new List<Extension>();

			while (reader.Read()) {
				extensions.Add(MapFromReader(reader));
			}

			return extensions;
		}

		public static List<Extension> GetAllExtensions() {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM extensions", connection);
				command.Connection.Open();

				using (NpgsqlDataReader reader = command.ExecuteReader()) {
					var extensions = MapListFromReader(reader);
					extensions.Sort((a, b) => {
						return a.Ext.CompareTo(b.Ext);
					});

					return extensions;
				}
			}
		}

		public static Extension GetExtension(string ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM extensions WHERE ext = @extension", connection)) {

					command.Parameters.AddWithValue("extension", ext);
					command.Connection.Open();

					using (NpgsqlDataReader reader = command.ExecuteReader()) {
						return MapListFromReader(reader).FirstOrDefault();
					}
				}
			}
		}

		public static void CreateExtension(Extension ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO public.extensions(ext, name, \"desc\", \"MIMEType\") VALUES(@ext, @name, @description, @MIMEType)", connection)) {

					command.Parameters.AddWithValue("ext", ext.Ext);
					command.Parameters.AddWithValue("name", ext.Name);
					command.Parameters.AddWithValue("description", ext.Desc ?? "");
					command.Parameters.AddWithValue("MIMEType", ext.MIMEType ?? "");
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void UpdateExtension(Extension ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("UPDATE public.extensions SET name=@name, \"desc\"=@description, \"MIMEType\"=@MIMEType WHERE ext=@extension", connection)) {

					command.Parameters.AddWithValue("extension", ext.Ext);
					command.Parameters.AddWithValue("name", ext.Name);
					command.Parameters.AddWithValue("description", ext.Desc);
					command.Parameters.AddWithValue("MIMEType", ext.MIMEType);
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void DeleteExtension(string ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM public.extensions WHERE ext=@extension", connection)) {

					command.Parameters.AddWithValue("extension", ext);
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}
	}
}
