using System.Collections.Generic;

namespace MyBooks.Client.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverUrl { get; set; }

        public string Summary { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public string GoodreadsUrl { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}