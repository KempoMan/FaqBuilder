using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public PlatformViewModel Platform { get; set; }

        public int FaqId { get; set; }

        public Faq Faq { get; set; }

        public IEnumerable<Platform> Platforms { get; set; } = new List<Platform>();

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}