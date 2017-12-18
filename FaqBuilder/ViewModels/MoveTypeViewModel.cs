using FaqBuilder.Helpers;

namespace FaqBuilder.ViewModels
{
    public class MoveTypeViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}