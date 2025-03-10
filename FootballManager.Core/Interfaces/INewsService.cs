namespace FootballManager.Core.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Base;

    public interface INewsService : IService
    {
        string GetNewsByPreference(string preference);
        List<NewsItem> GetNews(string preference);
    }
}