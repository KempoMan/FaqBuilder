using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // public virtual IEnumerable<Move> Moves { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}