using System;
using l2l.Data.Model;

namespace l2l.Data.Repository
{
    public class CourseRepository
    {
        private readonly L2lDbContext db;

        public CourseRepository()
        {
            var factory = new L2lDbContextFactory();
            db = factory.CreateDbContext(new string[] {});

        }

        public CourseRepository(L2lDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Add(Course entity)
        {
            db.Courses.Add(entity);
        }

        public Course GetById(int Id)
        {
            return db.Courses.Find(Id);
        }

        public void Update(Course toUpdate)
        {
            db.Courses.Update(toUpdate);
        }

        public void Delete(Course toDelete)
        {
            db.Courses.Remove(toDelete);
        }
    }
}