namespace FootballManager.Core.Models
{
    using System.Collections.Generic;

    public class Trivia
    {
        public string Question { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string CorrectAnswer { get; set; }
    }
}