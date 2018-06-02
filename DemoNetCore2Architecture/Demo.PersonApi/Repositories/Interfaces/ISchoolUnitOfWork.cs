namespace Demo.PersonApi.Repositories.Interfaces
{
    public interface ISchoolUnitOfWork
    {
         IPersonRepository PersonRepository { get; }
         ICourseRepository CourseRepository { get; }
         void Commit();
    }
}