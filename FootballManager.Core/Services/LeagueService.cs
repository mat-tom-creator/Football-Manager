namespace FootballManager.Core.Services.League
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class LeagueService : ILeagueService
    {
        public string Execute()
        {
            return GetLeagueStandings();
        }

        public string GetLeagueStandings()
        {
            var sb = new StringBuilder();
            sb.AppendLine("League Standings:");
            sb.AppendLine("1. Manchester City - 28 points");
            sb.AppendLine("2. Arsenal - 26 points");
            sb.AppendLine("3. Liverpool - 24 points");
            sb.AppendLine("4. Manchester United - 22 points");
            return sb.ToString();
        }

        public List<LeagueTableEntry> GetLeagueTable(string leagueName)
        {
            List<LeagueTableEntry> table = new List<LeagueTableEntry>();
            
            if (leagueName == "Premier League" || string.IsNullOrEmpty(leagueName))
            {
                table.Add(new LeagueTableEntry { Position = 1, TeamName = "Manchester City", Played = 12, Won = 9, Drawn = 1, Lost = 2, GoalsFor = 32, GoalsAgainst = 10, GoalDifference = 22, Points = 28 });
                table.Add(new LeagueTableEntry { Position = 2, TeamName = "Arsenal", Played = 12, Won = 8, Drawn = 2, Lost = 2, GoalsFor = 24, GoalsAgainst = 11, GoalDifference = 13, Points = 26 });
                table.Add(new LeagueTableEntry { Position = 3, TeamName = "Liverpool", Played = 12, Won = 7, Drawn = 3, Lost = 2, GoalsFor = 28, GoalsAgainst = 12, GoalDifference = 16, Points = 24 });
                table.Add(new LeagueTableEntry { Position = 4, TeamName = "Manchester United", Played = 12, Won = 7, Drawn = 1, Lost = 4, GoalsFor = 19, GoalsAgainst = 17, GoalDifference = 2, Points = 22 });
                table.Add(new LeagueTableEntry { Position = 5, TeamName = "Chelsea", Played = 12, Won = 6, Drawn = 3, Lost = 3, GoalsFor = 26, GoalsAgainst = 15, GoalDifference = 11, Points = 21 });
                table.Add(new LeagueTableEntry { Position = 6, TeamName = "Tottenham", Played = 12, Won = 6, Drawn = 1, Lost = 5, GoalsFor = 22, GoalsAgainst = 19, GoalDifference = 3, Points = 19 });
                table.Add(new LeagueTableEntry { Position = 7, TeamName = "West Ham", Played = 12, Won = 5, Drawn = 2, Lost = 5, GoalsFor = 20, GoalsAgainst = 17, GoalDifference = 3, Points = 17 });
                table.Add(new LeagueTableEntry { Position = 8, TeamName = "Brighton", Played = 12, Won = 4, Drawn = 4, Lost = 4, GoalsFor = 14, GoalsAgainst = 16, GoalDifference = -2, Points = 16 });
                table.Add(new LeagueTableEntry { Position = 9, TeamName = "Wolves", Played = 12, Won = 5, Drawn = 1, Lost = 6, GoalsFor = 12, GoalsAgainst = 15, GoalDifference = -3, Points = 16 });
                table.Add(new LeagueTableEntry { Position = 10, TeamName = "Leicester City", Played = 12, Won = 4, Drawn = 3, Lost = 5, GoalsFor = 19, GoalsAgainst = 23, GoalDifference = -4, Points = 15 });
            }
            else if (leagueName == "La Liga")
            {
                table.Add(new LeagueTableEntry { Position = 1, TeamName = "Real Madrid", Played = 12, Won = 9, Drawn = 2, Lost = 1, GoalsFor = 28, GoalsAgainst = 8, GoalDifference = 20, Points = 29 });
                table.Add(new LeagueTableEntry { Position = 2, TeamName = "Barcelona", Played = 12, Won = 8, Drawn = 2, Lost = 2, GoalsFor = 30, GoalsAgainst = 12, GoalDifference = 18, Points = 26 });
                // Add more entries as needed
            }
            else if (leagueName == "Bundesliga")
            {
                table.Add(new LeagueTableEntry { Position = 1, TeamName = "Bayern Munich", Played = 11, Won = 9, Drawn = 1, Lost = 1, GoalsFor = 38, GoalsAgainst = 7, GoalDifference = 31, Points = 28 });
                table.Add(new LeagueTableEntry { Position = 2, TeamName = "Borussia Dortmund", Played = 11, Won = 8, Drawn = 0, Lost = 3, GoalsFor = 28, GoalsAgainst = 15, GoalDifference = 13, Points = 24 });
                // Add more entries as needed
            }
            else
            {
                // Generic data for any other league
                for (int i = 1; i <= 10; i++)
                {
                    table.Add(new LeagueTableEntry
                    {
                        Position = i,
                        TeamName = $"Team {i}",
                        Played = 12,
                        Won = 10 - i,
                        Drawn = 2,
                        Lost = i,
                        GoalsFor = 30 - i,
                        GoalsAgainst = 10 + i,
                        GoalDifference = 20 - 2*i,
                        Points = 32 - 3*i
                    });
                }
            }
            
            return table;
        }
    }
}