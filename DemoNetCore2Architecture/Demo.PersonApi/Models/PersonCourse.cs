using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.PersonApi.Models
{
    public class PersonCourse: IRowState
    {
        public int PersonId { get; set;}
        public int CourseId { get; set; }
        public int Score { get; set; }
        public Person Person { get; set; }
        public Course Course { get; set; }
        [NotMapped]
        public RowState RowState { get; set; }
    }
}