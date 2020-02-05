using System;
using l2l.Data.Model;

namespace l2l.Data.Tests
{
    public class DatabaseFixture : IDisposable
    {
        private readonly L2lDbContextFactory factory;


        public DatabaseFixture()
        {
            factory = new L2lDbContextFactory();
            var db = GetNewDbContext();
            db.Database.EnsureCreated();
        }

        public L2lDbContext GetNewDbContext()
        {
            return factory.CreateDbContext(new string[] {});
        }
        public void Dispose()
        {

                var db = GetNewDbContext();
                db.Database.EnsureDeleted();
                db.Dispose();
        }
    }
}