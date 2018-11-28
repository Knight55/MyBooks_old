using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Bll.Entities
{
    [Table("AUTHOR")]
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Writing> Writings { get; } = new List<Writing>();
    }
}