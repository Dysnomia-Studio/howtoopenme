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
	public class ExtToSoftDataAccess : IExtToSoftDataAccess {
		private readonly string connectionString;

		public ExtToSoftDataAccess(IOptions<AppSettings> appSettings) {
			connectionString = appSettings.Value.ConnectionString;
		}

		public static ExtToSoft MapFromReader(IDataReader reader) {
			var extToSoft = new ExtToSoft {
				ExtensionId = reader.GetString("ExtensionId"),
				ExtName = reader.GetString("extName"),

				SoftwareId = reader.GetString("SoftwareId"),
				SoftwareName = reader.GetString("SoftwareName"),

				Use = reader.GetInt32("use"),
				Free = reader.GetInt32("free"),

				Windows = reader.GetInt("windows"),
				MacOS = reader.GetInt("macos"),
				Linux = reader.GetInt("linux"),
				Android = reader.GetInt("android"),
				Ios = reader.GetInt("ios"),
			};

			return extToSoft;
		}

		public static ExtToSoft MapFromBlankReader(IDataReader reader) {
			reader.Read();

			return MapFromReader(reader);
		}

		public static List<ExtToSoft> MapListFromReader(IDataReader reader) {
			List<ExtToSoft> extToSoftList = new List<ExtToSoft>();

			while (reader.Read()) {
				extToSoftList.Add(MapFromReader(reader));
			}

			extToSoftList.Sort((a, b) => {
				if (a.ExtensionId.CompareTo(b.ExtensionId) == 0) {
					return a.SoftwareId.CompareTo(b.SoftwareId);
				}

				return a.ExtensionId.CompareTo(b.ExtensionId);
			});

			return extToSoftList;
		}

		public async Task<List<ExtToSoft>> GetAll() {
			using var connection = new NpgsqlConnection(connectionString);

			return MapListFromReader(
				await DbHelper.ExecuteQuery(
					connection,
					"SELECT \"extAndSoft\".ext as \"ExtensionId\", \"extAndSoft\".soft as \"SoftwareId\", \"extAndSoft\".\"extName\", \"extAndSoft\".\"use\", \"extAndSoft\".\"free\", softwares.name as \"SoftwareName\", softwares.windows, softwares.macos, softwares.linux, softwares.android, softwares.ios FROM \"extAndSoft\" INNER JOIN softwares ON softwares.smallname = \"extAndSoft\".soft"
				)
			);
		}

		public async Task<ExtToSoft> Get(string ext, string extName, string software) {
			using var connection = new NpgsqlConnection(connectionString);

			return MapFromBlankReader(await DbHelper.ExecuteQuery(connection, "SELECT \"extAndSoft\".ext as \"ExtensionId\", \"extAndSoft\".soft as \"SoftwareId\", \"extAndSoft\".\"extName\", \"extAndSoft\".\"use\", \"extAndSoft\".\"free\", softwares.name as \"SoftwareName\", softwares.windows, softwares.macos, softwares.linux, softwares.android, softwares.ios FROM \"extAndSoft\"  INNER JOIN softwares ON softwares.smallname = \"extAndSoft\".soft WHERE ext = @ext AND \"extName\"=@extName AND soft = @software", new Dictionary<string, object>() {
				{ "ext", ext },
				{ "extName", extName },
				{ "software", software }
			}));
		}
		public async Task Create(ExtToSoft extToSoft) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "INSERT INTO \"extAndSoft\"(ext, soft, use, free, \"extName\") VALUES(@ext, @soft, @use, @free, @extName)", new Dictionary<string, object>() {
				{ "ext", extToSoft.ExtensionId },
				{ "soft", extToSoft.SoftwareId },
				{ "use", extToSoft.Use },
				{ "free", extToSoft.Free },
				{ "extName", extToSoft.ExtName }
			});
		}
		public async Task Delete(string ext, string extName, string software) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "DELETE FROM \"extAndSoft\" WHERE ext = @ext AND \"extName\"=@extName AND soft = @software", new Dictionary<string, object>() {
				{ "ext", ext },
				{ "extName", extName },
				{ "software", software }
			});
		}
	}
}