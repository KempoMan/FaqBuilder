using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class MoveType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}