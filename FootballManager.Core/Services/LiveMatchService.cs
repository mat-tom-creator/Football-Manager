namespace FootballManager.Core.Services.LiveMatch
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class LiveMatchService : ILiveMatchService
    {
        public string Execute()
        {
            return GetMatchUpdates();
        }

        public string GetMatchUpdates()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Live Match Updates:");
            sb.AppendLine("Match: Manchester United vs Chelsea | Score: 2-1 | Time: 75 mins");
            return sb.ToString();
        }

        public List<Match> GetLiveMatches()
        {
            return new List<Match>
            {
                new Match { HomeTeam = "Manchester United", AwayTeam = "Chelsea", Score = "2-1", Time = "75'", Competition = "Premier League", Status = "In Progress" },
                new Match { HomeTeam = "Bayern Munich", AwayTeam = "Borussia Dortmund", Score = "3-0", Time = "60'", Competition = "Bundesliga", Status = "In Progress" },
                new Match { HomeTeam = "PSG", AwayTeam = "Marseille", Score = "1-1", Time = "45+2'", Competition = "Ligue 1", Status = "Half Time" },
                new Match { HomeTeam = "Barcelona", AwayTeam = "Real Madrid", Score = "0-0", Time = "Pre-match", Competition = "La Liga", Status = "Not Started" }
            };
        }
    }
}