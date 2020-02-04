using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace l2l.Data.Model
{
    public class L2lDbContextFactory : IDesignTimeDbContextFactory<L2lDbContext>
    {
        public L2lDbContext CreateDbContext(string[] args)
        {
            var oBuilder = new DbContextOptionsBuilder<L2lDbContext>();

            var basePath = Directory.GetCurrentDirectory();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var cBuilder = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.json")
                                .AddJsonFile($"appsettings.{environment}.json")
                                .AddEnvironmentVariables();


            oBuilder.UseSqlite("Data Source=l2l.db;");

            return new L2lDbContext(oBuilder.Options);
        }
    }
}