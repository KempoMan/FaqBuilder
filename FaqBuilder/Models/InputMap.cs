namespace FaqBuilder.Models
{
    public class InputMap
    {
        public int Id { get; set; }
        
        public string Input { get; set; }

        public string ConvertedInput { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}