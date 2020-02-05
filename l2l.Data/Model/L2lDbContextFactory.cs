using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace l2l.Data.Model
{
    public class L2lDbContextFactory : IDesignTimeDbContextFactory<L2lDbContext>, IDisposable
    {
        private readonly SqliteConnection connection;

        public L2lDbContextFactory()
        {
            var basePath = Directory.GetCurrentDirectory();

            var environment = Environment.GetEnvironmentVariable(GlobalStrings.ASPNETCORE_ENVIRONMENT);

            var cBuilder = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.json")
                                .AddJsonFile($"appsettings.{environment}.json", true) //true in case of no variables
                                .AddEnvironmentVariables();

            var config = cBuilder.Build();

            var cn = config.GetConnectionString(GlobalStrings.CONNECTION_NAME); //from appsettings

            connection = new SqliteConnection(cn);

            connection.Open();
        }

        public L2lDbContext CreateDbContext(string[] args)
        {
            var oBuilder = new DbContextOptionsBuilder<L2lDbContext>();

            oBuilder.UseSqlite(connection);

            return new L2lDbContext(oBuilder.Options);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}