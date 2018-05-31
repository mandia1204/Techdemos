namespace Demo.PersonApi.Models
{
    public class PersonCourse
    {
        public int PersonId { get; set;}
        public int CourseId { get; set; }
        public Person Person { get; set; }
        public Course Course { get; set; }
    }
}