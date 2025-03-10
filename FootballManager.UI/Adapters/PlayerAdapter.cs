namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;

    public class PlayerAdapter
    {
        private readonly IPlayerService _playerService;

        public PlayerAdapter(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public void PopulatePlayerProfile(string playerName, Label nameLabel, Label numberLabel,
            Label ageLabel, Label heightLabel, Label nationalityLabel, Label positionLabel, 
            Label clubLabel, ProgressBar pacePrg, ProgressBar shootingPrg, ProgressBar dribblingPrg,
            ProgressBar passingPrg, ProgressBar defensePrg, Label paceValue, Label shootingValue,
            Label dribblingValue, Label passingValue, Label defenseValue)
        {
            if (string.IsNullOrEmpty(playerName))
                throw new ArgumentException("Player name cannot be empty", nameof(playerName));
            
            // Get data from the service
            Player player = _playerService.GetPlayerDetails(playerName);
            
            // Update UI controls
            nameLabel.Text = player.Name;
            numberLabel.Text = player.Number;
            ageLabel.Text = player.Age;
            heightLabel.Text = player.Height;
            nationalityLabel.Text = player.Nationality;
            positionLabel.Text = player.Position;
            clubLabel.Text = player.Club;
            
            // Set stats
            pacePrg.Value = player.Pace;
            shootingPrg.Value = player.Shooting;
            dribblingPrg.Value = player.Dribbling;
            passingPrg.Value = player.Passing;
            defensePrg.Value = player.Defense;
            
            paceValue.Text = player.Pace.ToString();
            shootingValue.Text = player.Shooting.ToString();
            dribblingValue.Text = player.Dribbling.ToString();
            passingValue.Text = player.Passing.ToString();
            defenseValue.Text = player.Defense.ToString();
        }
    }
}