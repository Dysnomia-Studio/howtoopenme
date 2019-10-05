using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Npgsql;

namespace Dysnomia.HowToOpenMe.Common {
	public class SQLHelper {
		public static void BindParameters(NpgsqlParameterCollection parameters, Dictionary<string, object> parametersData) {
			if (parametersData != null) {
				foreach (KeyValuePair<string, object> kvp in parametersData) {
					parameters.AddWithValue(kvp.Key, kvp.Value);
				}
			}
		}

		public async static Task<IDataReader> ExecStoredProcedure<T>(NpgsqlConnection connection, string procName, Dictionary<string, object> parameters = null) {
			var command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = procName;

			BindParameters(command.Parameters, parameters);

			return await command.ExecuteReaderAsync();
		}

		public async static Task<IDataReader> ExecSelect(NpgsqlConnection connection, string sqlStatement, Dictionary<string, object> parameters = null) {
			using (NpgsqlCommand command = new NpgsqlCommand(sqlStatement, connection)) {
				command.Connection.Open();

				BindParameters(command.Parameters, parameters);

				return await command.ExecuteReaderAsync();
			}
		}

		public async static Task<int> Exec(NpgsqlConnection connection, string sqlStatement, Dictionary<string, object> parameters = null) {
			using (NpgsqlCommand command = new NpgsqlCommand(sqlStatement, connection)) {
				command.Connection.Open();

				BindParameters(command.Parameters, parameters);

				return await command.ExecuteNonQueryAsync();
			}
		}
	}
}
