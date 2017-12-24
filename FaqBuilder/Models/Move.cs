namespace FaqBuilder.Models
{
    public class Move
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MoveTypeId { get; set; }

        public MoveType MoveType { get; set; }

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public string Motion { get; set; }
    }
}