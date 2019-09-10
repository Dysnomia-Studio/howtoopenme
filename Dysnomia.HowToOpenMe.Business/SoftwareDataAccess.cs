using System.Collections.Generic;
using System.Linq;

using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.Business
{
    public class SoftwareDataAccess {
		public static Software MapFromReader(NpgsqlDataReader reader) {
			var ext = new Software() {
				SmallName = reader.GetString(reader.GetOrdinal("smallname")),
				Name = reader.GetString(reader.GetOrdinal("name")),
			};

			if (!reader.IsDBNull(reader.GetOrdinal("desc"))) {
				ext.Desc = reader.GetString(reader.GetOrdinal("desc"));
			}

			if (!reader.IsDBNull(reader.GetOrdinal("URL"))) {
				ext.URL = reader.GetString(reader.GetOrdinal("URL"));
			}

			if (!reader.IsDBNull(reader.GetOrdinal("Windows"))) {
				ext.Windows = reader.GetInt32(reader.GetOrdinal("Windows"));
			}
			if(ext.Windows < 0 || ext.Windows > 2) {
				ext.Windows = 0;
			}

			if (!reader.IsDBNull(reader.GetOrdinal("MacOS"))) {
				ext.MacOS = reader.GetInt32(reader.GetOrdinal("MacOS"));
			}
			if (ext.MacOS < 0 || ext.MacOS > 2) {
				ext.MacOS = 0;
			}

			if (!reader.IsDBNull(reader.GetOrdinal("Linux"))) {
				ext.Linux = reader.GetInt32(reader.GetOrdinal("Linux"));
			}
			if (ext.Linux < 0 || ext.Linux > 2) {
				ext.Linux = 0;
			}

			if (!reader.IsDBNull(reader.GetOrdinal("Android"))) {
				ext.Android = reader.GetInt32(reader.GetOrdinal("Android"));
			}
			if (ext.Android < 0 || ext.Android > 2) {
				ext.Android = 0;
			}

			if (!reader.IsDBNull(reader.GetOrdinal("IOS"))) {
				ext.IOS = reader.GetInt32(reader.GetOrdinal("IOS"));
			}
			if (ext.IOS < 0 || ext.Android > 2) {
				ext.IOS = 0;
			}

			return ext;
		}

		public static List<Software> MapListFromReader(NpgsqlDataReader reader) {
			List<Software> Softwares = new List<Software>();

			while (reader.Read()) {
				Softwares.Add(MapFromReader(reader));
			}

			return Softwares;
		}

		public static List<Software> GetAllSoftwares() {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM softwares", connection);
				command.Connection.Open();

				using (NpgsqlDataReader reader = command.ExecuteReader()) {
					var Softwares = MapListFromReader(reader);
					Softwares.Sort((a, b) => {
						return a.SmallName.CompareTo(b.SmallName);
					});

					return Softwares;
				}
			}
		}

		public static Software GetSoftware(string smallname) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM softwares WHERE smallname = @smallname", connection)) {

					command.Parameters.AddWithValue("smallname", smallname);
					command.Connection.Open();

					using (NpgsqlDataReader reader = command.ExecuteReader()) {
						return MapListFromReader(reader).FirstOrDefault();
					}
				}
			}
		}

		public static void CreateSoftware(Software ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO public.Softwares(smallname, name, \"desc\", url, windows, macos, linux, android, ios) VALUES(@smallname, @name, @description, @url, @windows, @macos, @linux, @android, @ios)", connection)) {

					command.Parameters.AddWithValue("smallname", ext.SmallName);
					command.Parameters.AddWithValue("name", ext.Name);
					command.Parameters.AddWithValue("description", ext.Desc ?? "");
					command.Parameters.AddWithValue("url", ext.URL ?? "");
					command.Parameters.AddWithValue("windows", ext.Windows);
					command.Parameters.AddWithValue("macos", ext.MacOS);
					command.Parameters.AddWithValue("linux", ext.Linux);
					command.Parameters.AddWithValue("android", ext.Android);
					command.Parameters.AddWithValue("ios", ext.IOS);
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void UpdateSoftware(Software ext) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("UPDATE public.softwares SET name=@name, \"desc\"=@description, url=@url, windows=@windows, macos=@macos, linux=@linux, android=@android, ios=@ios WHERE smallname=@smallname", connection)) {

					command.Parameters.AddWithValue("smallname", ext.SmallName);
					command.Parameters.AddWithValue("name", ext.Name);
					command.Parameters.AddWithValue("description", ext.Desc ?? "");
					command.Parameters.AddWithValue("url", ext.URL ?? "");
					command.Parameters.AddWithValue("windows", ext.Windows);
					command.Parameters.AddWithValue("macos", ext.MacOS);
					command.Parameters.AddWithValue("linux", ext.Linux);
					command.Parameters.AddWithValue("android", ext.Android);
					command.Parameters.AddWithValue("ios", ext.IOS);
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void DeleteSoftware(string smallname) {
			using (NpgsqlConnection connection =
					new NpgsqlConnection("***REMOVED***")) {

				using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM public.softwares WHERE smallname=@smallname", connection)) {

					command.Parameters.AddWithValue("smallname", smallname);
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}
	}
}
