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
	public class AliasDataAccess : IAliasDataAccess {
		private readonly string connectionString;

		public AliasDataAccess(IOptions<AppSettings> appSettings) {
			connectionString = appSettings.Value.ConnectionString;
		}

		public Alias MapFromReader(IDataReader reader) {
			return new Alias {
				Id = reader.GetInt("id"),
				Ext = reader.GetString("ext"),
				AliasExt = reader.GetString("alias"),
				ExtName = reader.GetString("extName"),
			};
		}

		public Alias MapFromBlankReader(IDataReader reader) {
			reader.Read();

			return MapFromReader(reader);
		}

		public List<Alias> MapListFromReader(IDataReader reader) {
			List<Alias> aliases = new List<Alias>();

			while (reader.Read()) {
				aliases.Add(MapFromReader(reader));
			}

			aliases.Sort((a, b) => {
				return a.Ext.CompareTo(b.Ext);
			});

			return aliases;
		}

		public async Task<List<Alias>> GetAllAliases() {
			using var connection = new NpgsqlConnection(connectionString);

			return MapListFromReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM aliases"));
		}

		public async Task<Alias> GetAlias(int id) {
			using var connection = new NpgsqlConnection(connectionString);

			return MapFromBlankReader(await DbHelper.ExecuteQuery(connection, "SELECT * FROM aliases WHERE id = @id", new Dictionary<string, object>() {
				{ "id", id }
			}));
		}

		public async Task CreateAlias(Alias alias) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "INSERT INTO public.aliases(ext, alias, \"extName\") VALUES(@ext, @alias, @extName)", new Dictionary<string, object>() {
				{ "ext", alias.Ext },
				{ "alias", alias.AliasExt },
				{ "extName", alias.ExtName }
			});
		}

		public async Task UpdateAlias(Alias alias) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "UPDATE public.aliases SET ext=@ext, alias=@alias, \"extName\"=@extName WHERE id=@id", new Dictionary<string, object>() {
				{ "ext", alias.Ext },
				{ "alias", alias.AliasExt },
				{ "extName", alias.ExtName },
				{ "id", alias.Id }
			});
		}

		public async Task DeleteAlias(int id) {
			using var connection = new NpgsqlConnection(connectionString);

			await DbHelper.ExecuteNonQuery(connection, "DELETE FROM public.aliases WHERE id=@id", new Dictionary<string, object>() {
				{ "id", id }
			});
		}
	}
}