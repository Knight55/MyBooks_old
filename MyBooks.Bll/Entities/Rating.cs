using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBooks.Bll.Entities
{
    [Table("RATING")]
    public class Rating
    {
        public int Id { get; set; }
        
        public int Value { get; set; }
        
        public Book Book { get; set; }
    }
}