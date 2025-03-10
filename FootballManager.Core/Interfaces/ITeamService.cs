namespace FootballManager.Core.Interfaces
{
    using Models;
    using Base;

    public interface ITeamService : IService
    {
        string GetTeamProfile(string teamName);
        Team GetTeamDetails(string teamName);
    }
}