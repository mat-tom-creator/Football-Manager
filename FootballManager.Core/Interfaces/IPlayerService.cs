namespace FootballManager.Core.Interfaces
{
    using Models;
    using Base;

    public interface IPlayerService : IService
    {
        string GetPlayerProfile(string playerName);
        Player GetPlayerDetails(string playerName);
    }
}