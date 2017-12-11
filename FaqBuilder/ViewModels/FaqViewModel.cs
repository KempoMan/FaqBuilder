using System.Collections.Generic;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class FaqViewModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public GameViewModel Game { get; set; }

        public string Description { get; set; }

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}