namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class NewsAdapter
    {
        private readonly INewsService _newsService;

        public NewsAdapter(INewsService newsService)
        {
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
        }

        public void PopulateNewsItems(FlowLayoutPanel flowPanel, string preference)
        {
            if (flowPanel == null)
                throw new ArgumentNullException(nameof(flowPanel));

            flowPanel.Controls.Clear();
            
            // Get data from the service
            List<NewsItem> newsItems = _newsService.GetNews(preference);
            
            // Create news panels for each item
            foreach (var news in newsItems)
            {
                AddNewsItem(flowPanel, news.Title, news.Content);
            }
        }

        private void AddNewsItem(FlowLayoutPanel flowPanel, string title, string content)
        {
            Panel newsPanel = new Panel
            {
                Width = flowPanel.Width - 25,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 10, 3, 0)
            };
            
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Width = newsPanel.Width - 10,
                Location = new Point(5, 5)
            };
            
            Label contentLabel = new Label
            {
                Text = content,
                Font = new Font("Segoe UI", 9),
                Width = newsPanel.Width - 10,
                Height = 80,
                Location = new Point(5, 30),
                AutoEllipsis = true
            };
            
            newsPanel.Controls.Add(titleLabel);
            newsPanel.Controls.Add(contentLabel);
            flowPanel.Controls.Add(newsPanel);
        }
    }
}