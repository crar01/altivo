using Altivo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Services
{
    public class DatabaseInitializer
    {
        private static SQLiteConnection _connection;
        private static readonly string _dbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Altivo.db");

        public DatabaseInitializer()
        {
        }

        public static void InitializeAsync()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(_dbPath);
                _connection.CreateTable<Activity>();
                _connection.CreateTable<ConcentrationSession>();

                SeedService.SeedDatabase(_connection);
            }
        }

        public static SQLiteConnection Connection()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(_dbPath);
            }

            return _connection;
        }

        public static void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
            }

        }        
    }
}
