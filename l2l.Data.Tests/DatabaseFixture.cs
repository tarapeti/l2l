using System;
using l2l.Data.Model;

namespace l2l.Data.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public L2lDbContext db { get; private set;} 


        public DatabaseFixture()
        {
            var factory = new L2lDbContextFactory();
            db = factory.CreateDbContext(new string[] {});
            db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            if (db != null)
            {
                db.Database.EnsureDeleted();
                db.Dispose();
                db =null;
            }
        }
    }
}