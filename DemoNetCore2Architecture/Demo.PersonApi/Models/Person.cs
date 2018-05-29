using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.PersonApi.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set;}
        public string Name { get; set;}
    }
}