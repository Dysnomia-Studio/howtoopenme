using System;
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

		public static string GetStringFromReader(IDataReader reader, string key, bool catchNull = true, string defaultValue = "") {
            var id = reader.GetOrdinal(key);

            if (!catchNull || !reader.IsDBNull(id)) {
                return reader.GetString(id);
            }

            return defaultValue;
        }

        public static int GetInt32FromReader(IDataReader reader, string key, bool catchNull = true, int defaultValue = 0) {
            var id = reader.GetOrdinal(key);

            if (!catchNull || !reader.IsDBNull(id)) {
                return reader.GetInt32(id);
            }

            return defaultValue;
        }

        public static int? GetNullableInt32FromReader(IDataReader reader, string key) {
            var id = reader.GetOrdinal(key);

            if (!reader.IsDBNull(id)) {
                return reader.GetInt32(id);
            }

            return null;
        }

        public static bool GetBooleanFromReader(IDataReader reader, string key, bool catchNull = true, bool defaultValue = false) {
            var id = reader.GetOrdinal(key);

            if (!catchNull || !reader.IsDBNull(id)) {
                return reader.GetBoolean(id);
            }

            return defaultValue;
        }

        public static DateTime GetDateTimeFromReader(IDataReader reader, string key, bool catchNull = true, DateTime defaultValue = new DateTime()) {
            var id = reader.GetOrdinal(key);

            if (!catchNull || !reader.IsDBNull(id)) {
                return reader.GetDateTime(id);
            }

            return defaultValue;
        }
    }
}
