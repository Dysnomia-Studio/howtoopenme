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
	public class SoftwareDataAccess : ISoftwareDataAccess {
		private readonly string connectionString;

		public SoftwareDataAccess(IOptions<AppSettings> appSettings) {
			connectionString = appSettings.Value.ConnectionString;
		}

		public static Software MapFromReader(IDataReader reader) {
			var ext = new Software {
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
			if (!reader.Read()) {
				return null;
			}

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

		public async Task<List<Software>> GetAllSoftwares() {
			using var connection = new NpgsqlConnection(connectionString);

			return MapListFromReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM softwares"));
		}

		public async Task<Software> GetSoftware(string smallname) {
			using var connection = new NpgsqlConnection(connectionString);

			return MapFromBlankReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM softwares WHERE smallname = @smallname", new Dictionary<string, object>() {
				{ "smallname", smallname }
			}));
		}

		public async Task CreateSoftware(Software soft) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "INSERT INTO public.Softwares(smallname, name, \"desc\", url, windows, macos, linux, android, ios) VALUES(@smallname, @name, @description, @url, @windows, @macos, @linux, @android, @ios)", new Dictionary<string, object>() {
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

		public async Task UpdateSoftware(Software soft) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "UPDATE public.softwares SET name=@name, \"desc\"=@description, url=@url, windows=@windows, macos=@macos, linux=@linux, android=@android, ios=@ios WHERE smallname=@smallname", new Dictionary<string, object>() {
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

		public async Task DeleteSoftware(string smallname) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "DELETE FROM public.softwares WHERE smallname=@smallname", new Dictionary<string, object>() {
				{ "smallname", smallname }
			});
		}

		public async Task<List<Software>> Search(string searchText) {
			using var connection = new NpgsqlConnection(connectionString);

			var reader = await DbHelper.ExecuteQuery(connection, "SELECT * FROM softwares WHERE smallname ILIKE @searchText OR name ILIKE @searchText", new Dictionary<string, object>() {
				{ "searchText", "%" + searchText + "%" },
			});

			return MapListFromReader(reader);
		}

		public async Task<List<Software>> GetTopSoftwares() {
			using var connection = new NpgsqlConnection(connectionString);

			var reader = await DbHelper.ExecuteQuery(connection, "SELECT *  FROM (SELECT SUM(\"viewCount\") as somme, soft FROM public.\"softViews\" WHERE \"date\" >= current_date - interval '30 days' GROUP BY soft ORDER BY somme DESC LIMIT 10) top INNER JOIN softwares ON softwares.smallname = top.soft");

			return MapListFromReader(reader);
		}

		public async Task AddView(string name) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "INSERT INTO public.\"softViews\"(soft, \"date\", \"viewCount\") VALUES (@name, current_date, 1) ON CONFLICT (soft, \"date\") DO UPDATE SET \"viewCount\" = public.\"softViews\".\"viewCount\" + 1;", new Dictionary<string, object>() {
				{ "name", name },
			});
		}
	}
}