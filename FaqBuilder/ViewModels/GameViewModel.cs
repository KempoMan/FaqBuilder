using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FaqBuilder.Helpers;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class GameViewModel: FaqBuilderViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Game Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Platform")]
        public int PlatformId { get; set; }

        public PlatformViewModel Platform { get; set; }

        //public int FaqId { get; set; }

        //public Faq Faq { get; set; }

        public IEnumerable<Platform> Platforms { get; set; } = new List<Platform>();

        public ICollection<Character> Characters { get; set; }
    }
}