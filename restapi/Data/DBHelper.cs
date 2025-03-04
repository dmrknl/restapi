using Dapper;
using restapi.Models;
using System.Data.SQLite;

namespace restapi.Helpers
{
    public static class DBHelper
    {
        private static string DbConnectionString = @"Data Source=C:\Users\Ali\source\repos\restapi\restapi\bin\Debug\net8.0\Db\musteri.db;Version=3;";

        private static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(DbConnectionString);
            connection.Open();
            return connection;
        }

        public static IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = GetConnection())
            {
                var query = "SELECT * FROM Musteri";
                return connection.Query<Customer>(query);
            }
        }

        public static Customer GetCustomer(int id)
        {
            using (var connection = GetConnection())
            {
                var query = "SELECT * FROM Musteri WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Customer>(query, new { Id = id });
            }
        }

        public static void InsertCustomer(Customer customer)
        {
            using (var connection = GetConnection())
            {
                var query = "INSERT INTO Musteri (MusteriNo, Adi, Soyadi, DogumTarihi, TelefonNo) VALUES (@MusteriNo, @Adi, @Soyadi, @DogumTarihi, @TelefonNo)";
                connection.Execute(query, customer);
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            using (var connection = GetConnection())
            {
                var query = "UPDATE Musteri SET MusteriNo = @MusteriNo, Adi = @Adi, Soyadi = @Soyadi, DogumTarihi = @DogumTarihi, TelefonNo = @TelefonNo WHERE Id = @Id";
                connection.Execute(query, customer);
            }
        }

        public static void DeleteCustomer(int id)
        {
            using (var connection = GetConnection())
            {
                var query = "DELETE FROM Musteri WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}

