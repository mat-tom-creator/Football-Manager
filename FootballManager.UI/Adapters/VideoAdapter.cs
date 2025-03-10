namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;

    public class VideoAdapter
    {
        private readonly IVideoService _videoService;

        public VideoAdapter(IVideoService videoService)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }

        public void PopulateVideoList(ListView videoList, string videoType)
        {
            if (videoList == null)
                throw new ArgumentNullException(nameof(videoList));

            videoList.Items.Clear();
            
            // Get data from the service
            List<VideoItem> videos = _videoService.GetVideos(videoType);
            
            // Populate ListView
            foreach (var video in videos)
            {
                AddVideoItem(videoList, video.Title, video.Duration, video.Date);
            }
        }

        private void AddVideoItem(ListView listView, string title, string duration, string date)
        {
            ListViewItem item = new ListViewItem(title);
            item.SubItems.Add(duration);
            item.SubItems.Add(date);
            listView.Items.Add(item);
        }
    }
}