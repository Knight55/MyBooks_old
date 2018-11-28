using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Bll.Entities
{
    [Table("PUBLISHER")]
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Edition> Editions { get; } = new List<Edition>();
    }
}