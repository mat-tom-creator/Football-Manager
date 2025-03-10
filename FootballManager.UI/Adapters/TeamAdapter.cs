namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;

    public class TeamAdapter
    {
        private readonly ITeamService _teamService;

        public TeamAdapter(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        public void PopulateTeamProfile(string teamName, Label fullNameLabel, Label stadiumLabel, 
            Label foundingYearLabel, Label coachLabel, DataGridView playersGrid)
        {
            if (string.IsNullOrEmpty(teamName))
                throw new ArgumentException("Team name cannot be empty", nameof(teamName));
            
            // Get data from the service
            Team team = _teamService.GetTeamDetails(teamName);
            
            // Update UI controls
            fullNameLabel.Text = team.FullName;
            stadiumLabel.Text = team.Stadium;
            foundingYearLabel.Text = team.FoundingYear;
            coachLabel.Text = team.Coach;
            
            // Populate players grid
            playersGrid.Rows.Clear();
            foreach (var player in team.Players)
            {
                playersGrid.Rows.Add(
                    player.Number,
                    player.Name,
                    player.Position,
                    player.Nationality,
                    player.Age
                );
            }
        }
    }
}