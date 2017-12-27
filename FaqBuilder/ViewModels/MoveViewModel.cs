using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FaqBuilder.Helpers;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class MoveViewModel : FaqBuilderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Move Type")]
        public int MoveTypeId { get; set; }

        public MoveType MoveType { get; set; }

        public int CharacterId { get; set; }

        public string Motion { get; set; }

        public IEnumerable<MoveType> MoveTypes { get; set; } = new List<MoveType>();
    }        
}