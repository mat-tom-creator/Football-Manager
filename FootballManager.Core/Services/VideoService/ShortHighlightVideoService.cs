namespace FootballManager.Core.Services.Video
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class ShortHighlightVideoService : IVideoService
    {
        private readonly string _videoType;

        public ShortHighlightVideoService() : this("goal") { }

        public ShortHighlightVideoService(string videoType)
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
            sb.AppendLine($"Fetching short highlight video of type: {type}");
            
            if (type == "goal")
            {
                sb.AppendLine("Highlight: Rashford's stunning goal in the 45th minute!");
            }
            else if (type == "save")
            {
                sb.AppendLine("Highlight: De Gea's crucial save in the 70th minute!");
            }
            else
            {
                sb.AppendLine("No highlights found for the specified type.");
            }
            
            return sb.ToString();
        }
        
        public List<VideoItem> GetVideos(string videoType)
        {
            var videos = new List<VideoItem>();
            
            if (videoType.Equals("Goal", StringComparison.OrdinalIgnoreCase))
            {
                videos.Add(new VideoItem 
                { 
                    Title = "Rashford's stunning goal vs Liverpool", 
                    Duration = "01:23", 
                    Date = "2024-11-03" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Bruno Fernandes free-kick goal vs Manchester City", 
                    Duration = "01:45", 
                    Date = "2024-10-27" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Last-minute winner by Ronaldo", 
                    Duration = "00:58", 
                    Date = "2024-10-15" 
                });
            }
            else if (videoType.Equals("Save", StringComparison.OrdinalIgnoreCase))
            {
                videos.Add(new VideoItem 
                { 
                    Title = "De Gea's crucial double save", 
                    Duration = "01:12", 
                    Date = "2024-11-05" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Penalty save by Alisson", 
                    Duration = "00:47", 
                    Date = "2024-10-22" 
                });
                
                videos.Add(new VideoItem 
                { 
                    Title = "Ederson's fingertip save", 
                    Duration = "00:38", 
                    Date = "2024-10-08" 
                });
            }
            else
            {
                videos.Add(new VideoItem 
                { 
                    Title = "Football highlights", 
                    Duration = "03:45", 
                    Date = "2024-11-01" 
                });
            }
            
            return videos;
        }
    }
}
