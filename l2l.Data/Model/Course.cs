using System;

namespace l2l.Data.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Course);

        }

        public bool Equals(Course course)
        {
            if(course == null){
                return false;
            }
            if(Id != course.Id || Name != course.Name){
                return false;
            }
            return true;
        }
    }
}