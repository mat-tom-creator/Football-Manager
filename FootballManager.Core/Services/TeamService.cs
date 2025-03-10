namespace FootballManager.Core.Services.Team
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class TeamService : ITeamService
    {
        public string Execute()
        {
            return GetTeamProfile("Manchester United");
        }

        public string GetTeamProfile(string teamName)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Team Profile: {teamName}");
            sb.AppendLine("Top Players: Bruno Fernandes, Marcus Rashford");
            sb.AppendLine("Coach: Erik ten Hag");
            return sb.ToString();
        }

        public Team GetTeamDetails(string teamName)
        {
            if (teamName == "Manchester United")
            {
                var team = new Team
                {
                    Name = teamName,
                    FullName = "Manchester United Football Club",
                    Stadium = "Old Trafford (74,310 capacity)",
                    FoundingYear = "1878",
                    Coach = "Erik ten Hag",
                    Players = new List<Player>
                    {
                        new Player { Number = "7", Name = "Cristiano Ronaldo", Position = "Forward", Nationality = "Portugal", Age = "37" },
                        new Player { Number = "10", Name = "Marcus Rashford", Position = "Forward", Nationality = "England", Age = "24" },
                        new Player { Number = "8", Name = "Bruno Fernandes", Position = "Midfielder", Nationality = "Portugal", Age = "27" },
                        new Player { Number = "6", Name = "Paul Pogba", Position = "Midfielder", Nationality = "France", Age = "29" },
                        new Player { Number = "5", Name = "Harry Maguire", Position = "Defender", Nationality = "England", Age = "29" },
                        new Player { Number = "1", Name = "David de Gea", Position = "Goalkeeper", Nationality = "Spain", Age = "31" }
                    }
                };
                return team;
            }
            else if (teamName == "Liverpool")
            {
                var team = new Team
                {
                    Name = teamName,
                    FullName = "Liverpool Football Club",
                    Stadium = "Anfield (53,394 capacity)",
                    FoundingYear = "1892",
                    Coach = "Jürgen Klopp",
                    Players = new List<Player>
                    {
                        new Player { Number = "11", Name = "Mohamed Salah", Position = "Forward", Nationality = "Egypt", Age = "30" },
                        new Player { Number = "9", Name = "Roberto Firmino", Position = "Forward", Nationality = "Brazil", Age = "30" },
                        new Player { Number = "10", Name = "Sadio Mané", Position = "Forward", Nationality = "Senegal", Age = "30" },
                        new Player { Number = "14", Name = "Jordan Henderson", Position = "Midfielder", Nationality = "England", Age = "31" },
                        new Player { Number = "4", Name = "Virgil van Dijk", Position = "Defender", Nationality = "Netherlands", Age = "30" },
                        new Player { Number = "1", Name = "Alisson Becker", Position = "Goalkeeper", Nationality = "Brazil", Age = "29" }
                    }
                };
                return team;
            }
            else
            {
                // Default data for other teams
                var team = new Team
                {
                    Name = teamName,
                    FullName = teamName + " Football Club",
                    Stadium = "Home Stadium",
                    FoundingYear = "1900",
                    Coach = "Head Coach",
                    Players = new List<Player>
                    {
                        new Player { Number = "10", Name = "Star Player", Position = "Forward", Nationality = "Country", Age = "28" },
                        new Player { Number = "8", Name = "Midfielder", Position = "Midfielder", Nationality = "Country", Age = "26" },
                        new Player { Number = "4", Name = "Defender", Position = "Defender", Nationality = "Country", Age = "25" },
                        new Player { Number = "1", Name = "Goalkeeper", Position = "Goalkeeper", Nationality = "Country", Age = "30" }
                    }
                };
                return team;
            }
        }
    }
}