namespace FootballManager.Core.Models
{
    using System.Collections.Generic;

    public class SearchResult
    {
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Match> Matches { get; set; } = new List<Match>();
    }
}