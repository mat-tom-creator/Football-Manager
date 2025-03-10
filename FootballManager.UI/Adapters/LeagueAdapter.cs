namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;

    public class LeagueAdapter
    {
        private readonly ILeagueService _leagueService;

        public LeagueAdapter(ILeagueService leagueService)
        {
            _leagueService = leagueService ?? throw new ArgumentNullException(nameof(leagueService));
        }

        public void PopulateLeagueStandings(string leagueName, DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            dataGridView.Rows.Clear();
            
            // Initialize columns if not already set
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("Position", "#");
                dataGridView.Columns.Add("TeamName", "Team");
                dataGridView.Columns.Add("Matches", "M");
                dataGridView.Columns.Add("Wins", "W");
                dataGridView.Columns.Add("Draws", "D");
                dataGridView.Columns.Add("Losses", "L");
                dataGridView.Columns.Add("GoalsScored", "GF");
                dataGridView.Columns.Add("GoalsConceded", "GA");
                dataGridView.Columns.Add("GoalDifference", "GD");
                dataGridView.Columns.Add("Points", "Pts");
            }
            
            // Get data from the service
            List<LeagueTableEntry> table = _leagueService.GetLeagueTable(leagueName);
            
            // Populate DataGridView
            foreach (var entry in table)
            {
                dataGridView.Rows.Add(
                    entry.Position.ToString(),
                    entry.TeamName,
                    entry.Played.ToString(),
                    entry.Won.ToString(),
                    entry.Drawn.ToString(),
                    entry.Lost.ToString(),
                    entry.GoalsFor.ToString(),
                    entry.GoalsAgainst.ToString(),
                    $"+{entry.GoalDifference}",
                    entry.Points.ToString()
                );
            }
        }
    }
}