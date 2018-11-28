using System.Collections.Generic;
using MyBooks.Bll.Entities;

namespace MyBooks.Api.Dtos
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public List<Author> Authors { get; set; }
    }
}