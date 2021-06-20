using P03._Database_Before.Contracts;

namespace P03._Database
{
    public class Courses
    {
        private ICourseData courseDatabase;

        public Courses(ICourseData courseDatabase)
        {
            this.courseDatabase = courseDatabase;
        }

        public void PrintAll()
        {
            var courses = courseDatabase.CourseNames();

            System.Console.WriteLine(string.Join(", ", courses));
        }

        public void PrintIds()
        {
            var courseIds = courseDatabase.CourseIds();

            System.Console.WriteLine(string.Join(", ", courseIds));
        }

        public void PrintById(int id)
        {
            var course = courseDatabase.GetCourseById(id);

            System.Console.WriteLine(course);
        }
    }
}
