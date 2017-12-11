using System;
using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class Platform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}