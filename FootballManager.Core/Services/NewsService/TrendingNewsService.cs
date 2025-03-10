namespace FootballManager.Core.Services.News
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class TrendingNewsService : INewsService
    {
        private readonly string _preference;

        public TrendingNewsService() : this("sports") { }

        public TrendingNewsService(string preference)
        {
            _preference = preference;
        }

        public string Execute()
        {
            return GetNewsByPreference(_preference);
        }

        public string GetNewsByPreference(string preference)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Fetching trending news based on preference: {preference}");
            
            if (preference == "sports")
            {
                sb.AppendLine("Trending News: Ronaldo scores a hat-trick in the derby!");
            }
            else if (preference == "politics")
            {
                sb.AppendLine("Trending News: Elections 2024—latest updates.");
            }
            else
            {
                sb.AppendLine("Trending News: Climate action summit gains momentum.");
            }
            
            return sb.ToString();
        }
        
        public List<NewsItem> GetNews(string preference)
        {
            var news = new List<NewsItem>();
            
            if (preference == "Sports")
            {
                news.Add(new NewsItem 
                { 
                    Title = "Ronaldo scores a hat-trick in the derby!", 
                    Content = "In a thrilling Manchester derby, Cristiano Ronaldo scored three goals to secure a 3-1 victory for Manchester United over Manchester City.",
                    Category = "Sports",
                    Date = "2024-03-15"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Premier League considering new VAR improvements", 
                    Content = "The Premier League is looking at potential improvements to the VAR system after controversy in recent matches.",
                    Category = "Sports",
                    Date = "2024-03-14"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Liverpool signs promising young talent", 
                    Content = "Liverpool FC has announced the signing of a promising 18-year-old midfielder from their academy to a 5-year professional contract.",
                    Category = "Sports",
                    Date = "2024-03-12"
                });
            }
            else if (preference == "Transfer News")
            {
                news.Add(new NewsItem 
                { 
                    Title = "Barcelona eyeing Premier League star", 
                    Content = "Barcelona are reportedly interested in signing a Premier League midfielder in the January transfer window.",
                    Category = "Transfer",
                    Date = "2024-03-15"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Real Madrid set to offer new contract to veteran defender", 
                    Content = "Real Madrid are preparing to offer a 1-year contract extension to their experienced defender.",
                    Category = "Transfer",
                    Date = "2024-03-13"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Top striker available on free transfer next summer", 
                    Content = "A top European striker has decided not to renew his contract and will be available on a free transfer next summer.",
                    Category = "Transfer",
                    Date = "2024-03-10"
                });
            }
            else
            {
                // Default news items
                news.Add(new NewsItem 
                { 
                    Title = "Top football news of the day", 
                    Content = "Latest updates from around the football world.",
                    Category = "General",
                    Date = "2024-03-15"
                });
            }
            
            return news;
        }
    }
}
