namespace FootballManager.Core.Services.Fixtures
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FixturesService : IFixturesService
    {
        public string Execute()
        {
            var sb = new StringBuilder();
            sb.Append(GetFixtures());
            sb.Append(GetResults());
            return sb.ToString();
        }

        public string GetFixtures()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Upcoming Fixtures:");
            sb.AppendLine("Manchester United vs Liverpool | 2024-11-15");
            sb.AppendLine("Chelsea vs Arsenal | 2024-11-16");
            return sb.ToString();
        }

        public string GetResults()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Recent Results:");
            sb.AppendLine("Manchester City 3-1 Tottenham | 2024-11-10");
            sb.AppendLine("Arsenal 2-2 Chelsea | 2024-11-09");
            return sb.ToString();
        }

        public List<Fixture> GetUpcomingFixtures()
        {
            return new List<Fixture>
            {
                new Fixture { HomeTeam = "Manchester United", AwayTeam = "Liverpool", DateTime = "2024-11-15 15:00", Competition = "Premier League" },
                new Fixture { HomeTeam = "Chelsea", AwayTeam = "Arsenal", DateTime = "2024-11-16 17:30", Competition = "Premier League" },
                new Fixture { HomeTeam = "Tottenham", AwayTeam = "Newcastle", DateTime = "2024-11-17 14:00", Competition = "Premier League" },
                new Fixture { HomeTeam = "Leicester City", AwayTeam = "Everton", DateTime = "2024-11-18 20:00", Competition = "Premier League" }
            };
        }

        public List<Result> GetRecentResults()
        {
            return new List<Result>
            {
                new Result { HomeTeam = "Manchester City", AwayTeam = "Tottenham", Score = "3-1", Competition = "Premier League" },
                new Result { HomeTeam = "Arsenal", AwayTeam = "Chelsea", Score = "2-2", Competition = "Premier League" },
                new Result { HomeTeam = "Liverpool", AwayTeam = "West Ham", Score = "2-0", Competition = "Premier League" },
                new Result { HomeTeam = "Aston Villa", AwayTeam = "Crystal Palace", Score = "1-0", Competition = "Premier League" }
            };
        }
    }
}