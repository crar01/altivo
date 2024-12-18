using Altivo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Services
{
    public static class SeedService
    {
        public static void SeedDatabase(SQLiteConnection connection)
        {
            SeedActivity(connection);
        }

        private static void SeedActivity(SQLiteConnection connection)
        {
            var seedDefaultActivity = Seed.DefaultActivity;
            var defaultActivity = connection.Find<Activity>(seedDefaultActivity.Id);
            if (defaultActivity == null)
            {
                connection.Insert(seedDefaultActivity);
            }
        }
    }
}
