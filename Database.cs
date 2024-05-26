using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace with_this_sacred_treasure_I_summon
{
    public static class Database
    {
        private static string connectionString = "server=localhost;user=root;database=CafeManagement;password=VOUD7Eh!";

        public static async Task<MySqlConnection> GetConnectionAsync()
        {
            var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public static async Task<bool> TestConnectionAsync()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка подключения к базе данных: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
