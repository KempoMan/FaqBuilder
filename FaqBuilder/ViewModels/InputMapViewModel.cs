using System.ComponentModel.DataAnnotations;
using FaqBuilder.Helpers;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class InputMapViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string ConvertedInput { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}