namespace FootballManager.Core.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Base;

    public interface IVideoService : IService
    {
        string FetchVideo(string type);
        List<VideoItem> GetVideos(string type);
    }
}