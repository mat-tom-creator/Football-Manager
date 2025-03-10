// FootballManager.Core/Factories/ServiceFactory.cs
namespace FootballManager.Core.Factories
{
    using Interfaces;
    using Interfaces.Base;
    using Services.LiveMatch;
    using Services.Fixtures;
    using Services.Team;
    using Services.Player;
    using Services.League;
    using Services.News;
    using Services.FanInteraction;
    using Services.Video;
    using Services.Search;
    using Services.UserAuthentication;
    using System;

    public static class ServiceFactory
    {
        public static ILiveMatchService CreateLiveMatchService()
        {
            return new LiveMatchService();
        }

        public static IFixturesService CreateFixturesService()
        {
            return new FixturesService();
        }

        public static ITeamService CreateTeamService()
        {
            return new TeamService();
        }

        public static IPlayerService CreatePlayerService()
        {
            return new PlayerService();
        }

        public static ILeagueService CreateLeagueService()
        {
            return new LeagueService();
        }

        public static INewsService CreateNewsService(string type, string preference = "")
        {
            return type.ToLower() switch
            {
                "trending" => new TrendingNewsService(preference),
                "personalized" => new PersonalizedNewsService(preference),
                _ => throw new ArgumentException($"Unknown news service type: {type}")
            };
        }

        public static IFanInteractionService CreateFanInteractionService(string type, string interactionType = "", string input = "")
        {
            return type.ToLower() switch
            {
                "poll" => new FanPollService(interactionType, input),
                "trivia" => new FanTriviaService(interactionType, input),
                _ => throw new ArgumentException($"Unknown fan interaction service type: {type}")
            };
        }

        public static IVideoService CreateVideoService(string type, string videoType = "")
        {
            return type.ToLower() switch
            {
                "highlight" => new ShortHighlightVideoService(videoType),
                "replay" => new FullMatchReplayVideoService(videoType),
                _ => throw new ArgumentException($"Unknown video service type: {type}")
            };
        }

        public static ISearchService CreateSearchService(string query = "")
        {
            return new SearchService(query);
        }

        public static IUserAuthenticationService CreateUserAuthenticationService()
        {
            return new UserAuthenticationService();
        }
    }
}