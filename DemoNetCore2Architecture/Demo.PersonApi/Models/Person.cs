using System.Collections.Generic;

namespace Demo.PersonApi.Models
{
    public class Person: IEntity
    {
        public Person() {
            Courses = new List<PersonCourse>();
        }
        
        public int PersonId { get; set;}
        public string Name { get; set;}
        public List<PersonCourse> Courses { get; set; }
        public List<Review> Reviews { get; set; }

        public int Id => PersonId;
    }
}