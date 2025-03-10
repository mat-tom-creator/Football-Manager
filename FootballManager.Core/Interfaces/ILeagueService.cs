namespace FootballManager.Core.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Base;

    public interface ILeagueService : IService
    {
        string GetLeagueStandings();
        List<LeagueTableEntry> GetLeagueTable(string leagueName);
    }
}