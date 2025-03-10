namespace FootballManager.Core.Interfaces
{
    using Models;
    using Base;

    public interface ISearchService : IService
    {
        string Search(string query);
        SearchResult GetSearchResults(string query);
    }
}