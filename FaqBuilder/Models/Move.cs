namespace FaqBuilder.Models
{
    public class Move
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MoveTypeId { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; }

        public string Motion { get; set; }
    }
}