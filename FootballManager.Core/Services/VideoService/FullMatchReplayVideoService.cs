namespace FootballManager.Core.Services.Video
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FullMatchReplayVideoService : IVideoService
    {
        private readonly string _videoType;

        public FullMatchReplayVideoService() : this("full") { }

        public FullMatchReplayVideoService(string videoType)
        {
            _videoType = videoType;
        }

        public string Execute()
        {
            return FetchVideo(_videoType);
        }

        public string FetchVideo(string type)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Fetching full match replay video of type: {type}");
            
            if (type == "full")
            {
                sb.AppendLine("Replaying the full match");
            }
            else if (type == "extended")
            {
                sb.AppendLine("Replaying extended highlights");
            }
            else
            {
                sb.AppendLine("Invalid type for match replay.");
            }
            
            return sb.ToString();
        }
        
        public List<VideoItem> GetVideos(string videoType)
        {
            var videos = new List<VideoItem>();
            
            if (videoType.Equals("Full", StringComparison.OrdinalIgnoreCase))
            {
                videos.Add(new VideoItem 
                { 
                    Title = "Manchester United vs Liverpool - Full Match", 
                    Duration = "1:52:30", 
                    Date = "2024-11-03" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Arsenal vs Chelsea - Full Match", 
                    Duration = "1:50:15", 
                    Date = "2024-10-29" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Manchester City vs Tottenham - Full Match", 
                    Duration = "1:51:45", 
                    Date = "2024-10-18" 
                });
            }
            else if (videoType.Equals("Extended", StringComparison.OrdinalIgnoreCase))
            {
                videos.Add(new VideoItem 
                { 
                    Title = "Manchester United vs Liverpool - Extended Highlights", 
                    Duration = "20:30", 
                    Date = "2024-11-03" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Arsenal vs Chelsea - Extended Highlights", 
                    Duration = "22:15", 
                    Date = "2024-10-29" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Manchester City vs Tottenham - Extended Highlights", 
                    Duration = "18:45", 
                    Date = "2024-10-18" 
                });
            }
            else
            {
                videos.Add(new VideoItem 
                { 
                    Title = "Match Replay", 
                    Duration = "1:45:00", 
                    Date = "2024-11-01" 
                });
            }
            
            return videos;
        }
    }
}