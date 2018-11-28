using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Bll.Entities
{
    [Table("BOOK")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Writing> Writings { get; } = new List<Writing>();

        public ICollection<Edition> Editions { get; } = new List<Edition>();
    }
}