using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //public int FaqId { get; set; }

        //public Faq Faq { get; set; }

        //public IEnumerable<MoveType> MoveTypes { get; set; }

        public virtual ICollection<Character> Characters { get; set; }


    }
}