using System.ComponentModel.DataAnnotations.Schema;

namespace MyBooks.Bll.Entities
{
    [Table("WRITING")]
    public class Writing
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}