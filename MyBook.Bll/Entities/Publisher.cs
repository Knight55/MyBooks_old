using System.Collections.Generic;

namespace MyBook.Bll.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Edition> Editions { get; } = new List<Edition>();
    }
}