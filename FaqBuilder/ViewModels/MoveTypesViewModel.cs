using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class MoveTypesViewModel
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public ICollection<MoveType> MoveTypes { get; set; }
    }
}