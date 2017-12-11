namespace FaqBuilder.Models
{
    public class MoveType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}