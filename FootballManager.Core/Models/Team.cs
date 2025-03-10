namespace FootballManager.Core.Models
{
    using System.Collections.Generic;

    public class Team
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Stadium { get; set; }
        public string FoundingYear { get; set; }
        public string Coach { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}