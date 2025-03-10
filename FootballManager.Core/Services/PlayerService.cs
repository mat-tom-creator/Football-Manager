namespace FootballManager.Core.Services.Player
{
    using Interfaces;
    using Models;
    using System;
    using System.Text;

    public sealed class PlayerService : IPlayerService
    {
        public string Execute()
        {
            return GetPlayerProfile("Marcus Rashford");
        }

        public string GetPlayerProfile(string playerName)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Player Profile: {playerName}");
            sb.AppendLine("Position: Forward");
            sb.AppendLine("Goals: 15 | Assists: 8");
            return sb.ToString();
        }

        public Player GetPlayerDetails(string playerName)
        {
            if (playerName.ToLower().Contains("rashford"))
            {
                return new Player
                {
                    Name = "Marcus Rashford",
                    Number = "#10",
                    Age = "24",
                    Height = "1.85m",
                    Nationality = "England",
                    Position = "Forward",
                    Club = "Manchester United",
                    Pace = 86,
                    Shooting = 81,
                    Dribbling = 85,
                    Passing = 79,
                    Defense = 74
                };
            }
            else if (playerName.ToLower().Contains("fernandes") || playerName.ToLower().Contains("bruno"))
            {
                return new Player
                {
                    Name = "Bruno Fernandes",
                    Number = "#8",
                    Age = "27",
                    Height = "1.79m",
                    Nationality = "Portugal",
                    Position = "Midfielder",
                    Club = "Manchester United",
                    Pace = 75,
                    Shooting = 88,
                    Dribbling = 83,
                    Passing = 90,
                    Defense = 68
                };
            }
            else if (playerName.ToLower().Contains("salah"))
            {
                return new Player
                {
                    Name = "Mohamed Salah",
                    Number = "#11",
                    Age = "30",
                    Height = "1.75m",
                    Nationality = "Egypt",
                    Position = "Forward",
                    Club = "Liverpool",
                    Pace = 90,
                    Shooting = 87,
                    Dribbling = 89,
                    Passing = 83,
                    Defense = 45
                };
            }
            else
            {
                // Default player (not found)
                return new Player
                {
                    Name = playerName + " (Player not found)",
                    Number = "N/A",
                    Age = "N/A",
                    Height = "N/A",
                    Nationality = "N/A",
                    Position = "N/A",
                    Club = "N/A",
                    Pace = 0,
                    Shooting = 0,
                    Dribbling = 0,
                    Passing = 0,
                    Defense = 0
                };
            }
        }
    }
}