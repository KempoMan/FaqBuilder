using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class Move
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MoveTypeId { get; set; }

        public MoveType MoveType { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        public IEnumerable<ControllerInput> ControllerInputs { get; set; }
    }
}