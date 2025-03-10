namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;

    public class LiveMatchAdapter
    {
        private readonly ILiveMatchService _liveMatchService;

        public LiveMatchAdapter(ILiveMatchService liveMatchService)
        {
            _liveMatchService = liveMatchService ?? throw new ArgumentNullException(nameof(liveMatchService));
        }

        public void PopulateMatchDataGrid(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            dataGridView.Rows.Clear();
            
            // Get data from the service
            List<Match> matches = _liveMatchService.GetLiveMatches();
            
            // Populate DataGridView
            foreach (var match in matches)
            {
                dataGridView.Rows.Add(
                    match.HomeTeam,
                    match.Score,
                    match.AwayTeam,
                    match.Time,
                    match.Competition,
                    match.Status
                );
            }
        }
    }
}