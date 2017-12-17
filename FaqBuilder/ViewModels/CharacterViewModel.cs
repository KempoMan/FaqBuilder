using FaqBuilder.Helpers;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class CharacterViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}