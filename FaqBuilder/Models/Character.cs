using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public virtual ICollection<Move> Moves { get; set; } = new List<Move>();

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}