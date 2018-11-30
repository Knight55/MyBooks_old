using System.Collections.Generic;

namespace MyBooks.Client.Models
{
    public class Book
    {
        public string Title { get; set; }

        public Genre Genre { get; set; }

        public List<Author> Authors { get; set; }
    }
}