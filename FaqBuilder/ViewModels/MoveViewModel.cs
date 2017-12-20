using System.Collections.Generic;
using FaqBuilder.Helpers;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class MoveViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MoveTypeId { get; set; }

        public int CharacterId { get; set; }

        public string Motion { get; set; }

        public IEnumerable<MoveType> MoveTypes { get; set; } = new List<MoveType>();
    }        
}