using System.Collections.Generic;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;

namespace Demo.PersonApi.Services
{
    public class PersonServiceUoW : IPersonService
    {
        private readonly ISchoolUnitOfWork schoolUnitOfWork;
        public PersonServiceUoW(ISchoolUnitOfWork schoolUnitOfWork) {
            this.schoolUnitOfWork = schoolUnitOfWork;
        }

        public ApiResponse<Person> Create(Person person)
        {
            var response = new ApiResponse<Person> {};
            schoolUnitOfWork.PersonRepository.Add(person);

            var course = new Course{
                CourseName = "My Course"
            };

            schoolUnitOfWork.CourseRepository.Add(course);

            schoolUnitOfWork.Commit();
            response.Data = person;
            return response;
        }

        public ApiResponse<Person> Delete(int personId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Person GetById(int personId)
        {
            throw new System.NotImplementedException();
        }

        public ApiResponse<Person> Update(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}