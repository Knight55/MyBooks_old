using System.Collections.Generic;

namespace MyBooks.Api.Dtos
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}