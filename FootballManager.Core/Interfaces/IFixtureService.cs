namespace FootballManager.Core.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Base;

    public interface IFixturesService : IService
    {
        string GetFixtures();
        string GetResults();
        
        List<Fixture> GetUpcomingFixtures();
        List<Result> GetRecentResults();
    }
}