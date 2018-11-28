using System.Collections.Generic;

namespace MyBook.Bll.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Writing> Writings { get; } = new List<Writing>();
    }
}