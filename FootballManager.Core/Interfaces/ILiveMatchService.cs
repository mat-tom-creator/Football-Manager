namespace FootballManager.Core.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Base;

    public interface ILiveMatchService : IService
    {
        string GetMatchUpdates();
        List<Match> GetLiveMatches();
    }
}