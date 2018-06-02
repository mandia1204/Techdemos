using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;

namespace Demo.PersonApi.Repositories
{
    public class CourseRepository: ICourseRepository
    {
        private readonly SchoolContext context;
        public CourseRepository(SchoolContext context) {
            this.context = context;
        }
        public void Add(Course course)
        {
            context.Courses.Add(course);
        }
    }
}