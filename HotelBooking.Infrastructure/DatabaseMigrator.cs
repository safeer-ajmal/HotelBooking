using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp;

namespace HotelBooking.Infrastructure
{
    public class DatabaseMigrator
    {
        private readonly string _connectionString;
        public DatabaseMigrator(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void RunMigrations()
        {
            var upgrader = DeployChanges.To
                .SqlDatabase(_connectionString)
                .WithScriptsEmbeddedInAssembly(System.Reflection.Assembly.GetExecutingAssembly())
                .WithTransaction()
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database migration failed!");
                Console.WriteLine(result.Error);
                Console.ResetColor();
                throw new Exception("Migration failed.", result.Error);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database migrated successfully!");
            Console.ResetColor();
        }
    }

    }

