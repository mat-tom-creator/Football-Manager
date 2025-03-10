namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;

    public class SearchAdapter
    {
        private readonly ISearchService _searchService;

        public SearchAdapter(ISearchService searchService)
        {
            _searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
        }

        public void PopulateSearchResults(string query, ListView teamResults, ListView playerResults, ListView matchResults)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Search query cannot be empty", nameof(query));
            
            // Clear previous results
            teamResults.Items.Clear();
            playerResults.Items.Clear();
            matchResults.Items.Clear();
            
            // Get data from the service
            SearchResult results = _searchService.GetSearchResults(query);
            
            // Populate Team results
            foreach (var team in results.Teams)
            {
                ListViewItem item = new ListViewItem(team.Name);
                item.SubItems.Add(team.FullName);
                item.SubItems.Add(team.Stadium);
                item.SubItems.Add(team.FoundingYear);
                teamResults.Items.Add(item);
            }
            
            // Populate Player results
            foreach (var player in results.Players)
            {
                ListViewItem item = new ListViewItem(player.Name);
                item.SubItems.Add(player.Club);
                item.SubItems.Add(player.Position);
                item.SubItems.Add(player.Nationality);
                playerResults.Items.Add(item);
            }
            
            // Populate Match results
            foreach (var match in results.Matches)
            {
                ListViewItem item = new ListViewItem(match.HomeTeam);
                item.SubItems.Add(match.AwayTeam);
                item.SubItems.Add(match.Score);
                item.SubItems.Add(match.Competition);
                item.SubItems.Add(match.Time);
                matchResults.Items.Add(item);
            }
        }
    }
}
