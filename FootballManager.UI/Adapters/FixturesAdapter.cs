namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;

    public class FixturesAdapter
    {
        private readonly IFixturesService _fixturesService;

        public FixturesAdapter(IFixturesService fixturesService)
        {
            _fixturesService = fixturesService ?? throw new ArgumentNullException(nameof(fixturesService));
        }

        public void PopulateFixturesDataGrid(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            dataGridView.Rows.Clear();
            
            // Get data from the service
            List<Fixture> fixtures = _fixturesService.GetUpcomingFixtures();
            
            // Populate DataGridView
            foreach (var fixture in fixtures)
            {
                dataGridView.Rows.Add(
                    fixture.HomeTeam,
                    fixture.AwayTeam,
                    fixture.DateTime,
                    fixture.Competition
                );
            }
        }

        public void PopulateResultsDataGrid(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            dataGridView.Rows.Clear();
            
            // Get data from the service
            List<Result> results = _fixturesService.GetRecentResults();
            
            // Populate DataGridView
            foreach (var result in results)
            {
                dataGridView.Rows.Add(
                    result.HomeTeam,
                    result.AwayTeam,
                    result.Score,
                    result.Competition
                );
            }
        }
    }
}