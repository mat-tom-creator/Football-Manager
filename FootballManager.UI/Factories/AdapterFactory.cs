// FootballManager.UI/Factories/AdapterFactory.cs
namespace FootballManager.UI.Factories
{
    using FootballManager.Core.Factories;
    using FootballManager.Core.Interfaces;
    using FootballManager.UI.Adapters;
    using System;

    public static class AdapterFactory
    {
        public static LiveMatchAdapter CreateLiveMatchAdapter()
        {
            ILiveMatchService service = ServiceFactory.CreateLiveMatchService();
            return new LiveMatchAdapter(service);
        }

        public static FixturesAdapter CreateFixturesAdapter()
        {
            IFixturesService service = ServiceFactory.CreateFixturesService();
            return new FixturesAdapter(service);
        }

        public static TeamAdapter CreateTeamAdapter()
        {
            ITeamService service = ServiceFactory.CreateTeamService();
            return new TeamAdapter(service);
        }

        public static PlayerAdapter CreatePlayerAdapter()
        {
            IPlayerService service = ServiceFactory.CreatePlayerService();
            return new PlayerAdapter(service);
        }

        public static LeagueAdapter CreateLeagueAdapter()
        {
            ILeagueService service = ServiceFactory.CreateLeagueService();
            return new LeagueAdapter(service);
        }

        public static NewsAdapter CreateNewsAdapter(string type, string preference = "")
        {
            INewsService service = ServiceFactory.CreateNewsService(type, preference);
            return new NewsAdapter(service);
        }

        public static VideoAdapter CreateVideoAdapter(string type, string videoType = "")
        {
            IVideoService service = ServiceFactory.CreateVideoService(type, videoType);
            return new VideoAdapter(service);
        }

        public static FanInteractionAdapter CreateFanInteractionAdapter(string type, string interactionType = "", string input = "")
        {
            IFanInteractionService service = ServiceFactory.CreateFanInteractionService(type, interactionType, input);
            return new FanInteractionAdapter(service);
        }

        public static SearchAdapter CreateSearchAdapter(string query = "")
        {
            ISearchService service = ServiceFactory.CreateSearchService(query);
            return new SearchAdapter(service);
        }
    }
}