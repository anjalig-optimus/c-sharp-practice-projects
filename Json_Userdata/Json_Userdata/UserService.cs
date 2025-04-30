using Microsoft.Data.SqlClient;
using System.Data;

namespace Json_Userdata
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> GetUserDataAsync(string jsonData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("spuserdata", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the JSON parameter dynamically
                    command.Parameters.Add(new SqlParameter("@inputjson", SqlDbType.NVarChar)
                    {
                        Value = jsonData
                    });

                    var result = await command.ExecuteScalarAsync();

                    // For this example, assume the stored procedure returns the result as a JSON or string
                    return result.ToString();
                }
            }
        }
        public async Task AddUserDataAsync(string jsonData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("spInsertUserData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the JSON parameter dynamically
                    command.Parameters.Add(new SqlParameter("@inputjson", SqlDbType.NVarChar)
                    {
                        Value = jsonData
                    });

                    // Execute the stored procedure to insert the data
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
