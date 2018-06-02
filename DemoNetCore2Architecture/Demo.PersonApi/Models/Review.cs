using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.PersonApi.Models
{
    public class Review: IRowState
    {
        public int ReviewId { get; set; }
        public int PersonId { get; set; }
        public string Comment { get; set; }
        [NotMapped]
        public RowState RowState { get; set; }
    }
}