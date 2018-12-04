using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBooks.Bll.Entities
{
    [Table("BOOK")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImagePath { get; set; }

        public string Summary { get; set; }

        public Genre Genre { get; set; }
        
        public Rating Rating { get; set; }

        public string GoodreadsId { get; set; }

        public int MyProperty { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; } = new List<BookAuthor>();

        public ICollection<Edition> Editions { get; } = new List<Edition>();
    }
}