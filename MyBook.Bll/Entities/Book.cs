using System.Collections.Generic;

namespace MyBook.Bll.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Genre> Genres { get; set; }

        public ICollection<Writing> Writings { get; } = new List<Writing>();

        public ICollection<Edition> Editions { get; } = new List<Edition>();
    }
}