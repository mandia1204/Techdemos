using System.Collections.Generic;

namespace Demo.PersonApi.Models
{
    public class Person
    {
        public Person() {
            Courses = new List<PersonCourse>();
        }
        
        public int PersonId { get; set;}
        public string Name { get; set;}
        public List<PersonCourse> Courses { get; set; }
    }
}