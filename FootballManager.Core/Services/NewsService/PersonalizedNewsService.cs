namespace FootballManager.Core.Services.News
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class PersonalizedNewsService : INewsService
    {
        private readonly string _preference;

        public PersonalizedNewsService() : this("football") { }

        public PersonalizedNewsService(string preference)
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
            sb.AppendLine($"Fetching personalized news for preference: {preference}");
            
            if (preference == "football")
            {
                sb.AppendLine("Personalized News: Your favorite team won the match!");
            }
            else if (preference == "technology")
            {
                sb.AppendLine("Personalized News: AI breakthroughs in 2025.");
            }
            else
            {
                sb.AppendLine("Personalized News: Top stories you might like.");
            }
            
            return sb.ToString();
        }
        
        public List<NewsItem> GetNews(string preference)
        {
            var news = new List<NewsItem>();
            
            if (preference == "Football")
            {
                news.Add(new NewsItem 
                { 
                    Title = "Your favorite team won the match!", 
                    Content = "Manchester United secured a convincing 3-0 victory in their latest Premier League fixture.",
                    Category = "Football",
                    Date = "2024-03-15"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Bruno Fernandes nominated for Player of the Month", 
                    Content = "Manchester United's Bruno Fernandes has been nominated for the Premier League Player of the Month award after his outstanding performances.",
                    Category = "Football",
                    Date = "2024-03-14"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "Old Trafford set for expansion", 
                    Content = "Manchester United have announced plans to expand Old Trafford's capacity by an additional 15,000 seats.",
                    Category = "Football",
                    Date = "2024-03-10"
                });
            }
            else if (preference == "International")
            {
                news.Add(new NewsItem 
                { 
                    Title = "England announce squad for upcoming international fixtures", 
                    Content = "The England manager has announced his 26-man squad for the upcoming World Cup qualifiers.",
                    Category = "International",
                    Date = "2024-03-15"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "World Cup 2026 preparation begins", 
                    Content = "FIFA has started the preparation process for the 2026 World Cup which will be hosted in the United States, Canada, and Mexico.",
                    Category = "International",
                    Date = "2024-03-12"
                });
                
                news.Add(new NewsItem 
                { 
                    Title = "International transfer window changes proposed", 
                    Content = "FIFA is considering changes to the international transfer window to align better with continental competitions.",
                    Category = "International",
                    Date = "2024-03-08"
                });
            }
            else
            {
                // Default news items
                news.Add(new NewsItem 
                { 
                    Title = "Personalized football news", 
                    Content = "Content based on your preferences and viewing history.",
                    Category = "Personalized",
                    Date = "2024-03-15"
                });
            }
            
            return news;
        }
    }
}