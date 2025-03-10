namespace FootballManager.Core.Services.Search
{
    using Interfaces;
    using Models;
    using System;
    using System.Text;

    public sealed class SearchService : ISearchService
    {
        private readonly string _query;

        public SearchService() : this(string.Empty) { }

        public SearchService(string query)
        {
            _query = query;
        }
        
        public string Execute()
        {
            return Search(_query);
        }

        public string Search(string query)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Search Results for '{query}':");
            sb.AppendLine("Manchester United vs Chelsea");
            sb.AppendLine("Cristiano Ronaldo");
            sb.AppendLine("Premier League");
            return sb.ToString();
        }
        
        public SearchResult GetSearchResults(string query)
        {
            SearchResult results = new SearchResult();
            
            // Convert query to lowercase for case-insensitive search
            string lowercaseQuery = query.ToLower();
            
            // Team results
            if ("manchester united".Contains(lowercaseQuery))
            {
                results.Teams.Add(new Team { 
                    Name = "Manchester United", 
                    FullName = "Manchester United Football Club",
                    Stadium = "Old Trafford",
                    FoundingYear = "1878" 
                });
            }
            
            if ("liverpool".Contains(lowercaseQuery))
            {
                results.Teams.Add(new Team { 
                    Name = "Liverpool", 
                    FullName = "Liverpool Football Club",
                    Stadium = "Anfield",
                    FoundingYear = "1892" 
                });
            }
            
            // Player results
            if ("ronaldo".Contains(lowercaseQuery))
            {
                results.Players.Add(new Player { 
                    Name = "Cristiano Ronaldo", 
                    Club = "Manchester United", 
                    Position = "Forward", 
                    Nationality = "Portugal" 
                });
            }
            
            if ("messi".Contains(lowercaseQuery))
            {
                results.Players.Add(new Player { 
                    Name = "Lionel Messi", 
                    Club = "PSG", 
                    Position = "Forward", 
                    Nationality = "Argentina" 
                });
            }
            
            // Match results
            if ("manchester".Contains(lowercaseQuery))
            {
                results.Matches.Add(new Match { 
                    HomeTeam = "Manchester United", 
                    AwayTeam = "Chelsea", 
                    Score = "2-1", 
                    Competition = "Premier League", 
                    Time = "2024-11-03" 
                });
                
                results.Matches.Add(new Match { 
                    HomeTeam = "Manchester City", 
                    AwayTeam = "Tottenham", 
                    Score = "3-1", 
                    Competition = "Premier League", 
                    Time = "2024-11-10" 
                });
            }
            
            return results;
        }
    }
}