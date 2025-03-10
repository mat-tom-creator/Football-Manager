namespace FootballManager.Core.Models
{
    using System.Collections.Generic;

    public class Poll
    {
        public string Question { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public Dictionary<string, int> Results { get; set; } = new Dictionary<string, int>();
    }
}