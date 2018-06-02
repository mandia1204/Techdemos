using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Repositories.Interfaces;

namespace Demo.PersonApi.Repositories
{
    public class SchoolUnitOfWork : ISchoolUnitOfWork
    {
        private readonly SchoolContext context;
        public SchoolUnitOfWork(SchoolContext context, IPersonRepository personRepository, ICourseRepository courseRepository) {
            this.context = context;
            this.PersonRepository = personRepository;
            this.CourseRepository = courseRepository;
        }
        public IPersonRepository PersonRepository { get; }
        public ICourseRepository CourseRepository { get; }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}