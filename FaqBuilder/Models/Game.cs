using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<MoveType> MoveTypes { get; set; } = new List<MoveType>();

        public virtual ICollection<Character> Characters { get; set; } = new List<Character>();


    }
}