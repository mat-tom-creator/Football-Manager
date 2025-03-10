namespace FootballManager.Core.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        
        // Stats (0-100)
        public int Pace { get; set; }
        public int Shooting { get; set; }
        public int Dribbling { get; set; }
        public int Passing { get; set; }
        public int Defense { get; set; }
    }
}