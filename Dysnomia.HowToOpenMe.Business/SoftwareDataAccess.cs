using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dysnomia.Common.SQL;

using Dysnomia.HowToOpenMe.Common;
using Dysnomia.HowToOpenMe.Common.Models;

using Npgsql;

namespace Dysnomia.HowToOpenMe.Business {
	public class SoftwareDataAccess {
		public static string connectionString = "***REMOVED***";

		public static Software MapFromReader(IDataReader reader) {
			var ext = new Software() {
				SmallName = reader.GetString("smallname"),
				Name = reader.GetString("name"),
				Desc = reader.GetString("desc"),
				URL = reader.GetString("URL"),

				Windows = reader.GetInt32("Windows"),
				MacOS = reader.GetInt32("MacOS"),
				Linux = reader.GetInt32("Linux"),
				Android = reader.GetInt32("Android"),
				IOS = reader.GetInt32("IOS"),
			};

			return ext;
		}

		public static Software MapFromBlankReader(IDataReader reader) {
			reader.Read();

			return MapFromReader(reader);
		}

		public static List<Software> MapListFromReader(IDataReader reader) {
			List<Software> extensions = new List<Software>();

			while (reader.Read()) {
				extensions.Add(MapFromReader(reader));
			}

			extensions.Sort((a, b) => {
				return a.SmallName.CompareTo(b.SmallName);
			});

			return extensions;
		}

		public static async Task<List<Software>> GetAllSoftwares() {
			using var connection = new NpgsqlConnection(connectionString);

			return MapListFromReader(await SQLHelper.ExecSelect(connection, "SELECT * FROM softwares"));
		}

		public static async Task<Software> GetSoftware(string smallname) {
			using var connection = new NpgsqlConnection(connectionString);

			return MapFromBlankReader(await SQLHelper.ExecSelect(connection, "SELECT * FROM softwares WHERE smallname = @smallname", new Dictionary<string, object>() {
				{ "smallname", smallname }
			}));
		}

		public static async Task CreateSoftware(Software soft) {
			using var connection = new NpgsqlConnection(connectionString);

			await SQLHelper.Exec(connection, "INSERT INTO public.Softwares(smallname, name, \"desc\", url, windows, macos, linux, android, ios) VALUES(@smallname, @name, @description, @url, @windows, @macos, @linux, @android, @ios)", new Dictionary<string, object>() {
				{ "smallname", soft.SmallName },
				{ "name", soft.Name },
				{ "description", soft.Desc ?? "" },
				{ "url", soft.URL ?? "" },
				{ "windows", soft.Windows },
				{ "macos", soft.MacOS },
				{ "linux", soft.Linux },
				{ "android", soft.Android },
				{ "ios", soft.IOS },
			});
		}

		public static async Task UpdateSoftware(Software soft) {
			using var connection = new NpgsqlConnection(connectionString);

			await SQLHelper.Exec(connection, "UPDATE public.softwares SET name=@name, \"desc\"=@description, url=@url, windows=@windows, macos=@macos, linux=@linux, android=@android, ios=@ios WHERE smallname=@smallname", new Dictionary<string, object>() {
				{ "smallname", soft.SmallName },
				{ "name", soft.Name },
				{ "description", soft.Desc ?? "" },
				{ "url", soft.URL ?? "" },
				{ "windows", soft.Windows },
				{ "macos", soft.MacOS },
				{ "linux", soft.Linux },
				{ "android", soft.Android },
				{ "ios", soft.IOS },
			});
		}

		public static async Task DeleteSoftware(string smallname) {
			using var connection = new NpgsqlConnection(connectionString);

			await SQLHelper.Exec(connection, "DELETE FROM public.softwares WHERE smallname=@smallname", new Dictionary<string, object>() {
				{ "smallname", smallname }
			});
		}
	}
}
