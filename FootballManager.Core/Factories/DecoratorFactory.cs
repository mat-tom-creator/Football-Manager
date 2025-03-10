namespace FootballManager.Core.Factories
{
    using Decorators;
    using Interfaces.Base;
    using Interfaces;
    using System;

    public static class DecoratorFactory
    {
        public static IService AddLogging(IService service)
        {
            return new LoggingDecorator(service);
        }

        public static IService AddPerformanceMonitoring(IService service)
        {
            return new PerformanceDecorator(service);
        }

        public static IService AddCaching(IService service, string cacheKey = "default", TimeSpan? cacheDuration = null)
        {
            return new CachingDecorator(service, cacheKey, cacheDuration);
        }

        public static IService AddRetry(IService service, int maxRetries = 3, TimeSpan? delay = null)
        {
            return new RetryDecorator(service, maxRetries, delay);
        }

        public static IService AddAllDecorators(IService service)
        {
            // Apply decorators in order - logging first, then performance, then caching, then retry
            return new RetryDecorator(
                new CachingDecorator(
                    new PerformanceDecorator(
                        new LoggingDecorator(service)
                    )
                )
            );
        }

        // Common combinations
        public static IService AddReliabilityDecorators(IService service)
        {
            // For data that's expensive to fetch but can be cached
            return new CachingDecorator(
                new RetryDecorator(service)
            );
        }

        public static IService AddMonitoringDecorators(IService service)
        {
            // For monitoring performance and logging
            return new PerformanceDecorator(
                new LoggingDecorator(service)
            );
        }
        
        // Type-specific decorated services
        public static CachingDecorator CreateCachedTeamService(ITeamService teamService, TimeSpan? cacheDuration = null)
        {
            return new CachingDecorator(teamService, "team-service", cacheDuration);
        }
        
        public static CachingDecorator CreateCachedPlayerService(IPlayerService playerService, TimeSpan? cacheDuration = null)
        {
            return new CachingDecorator(playerService, "player-service", cacheDuration);
        }
        
        public static CachingDecorator CreateCachedLeagueService(ILeagueService leagueService, TimeSpan? cacheDuration = null)
        {
            return new CachingDecorator(leagueService, "league-service", cacheDuration);
        }
        
        public static RetryDecorator CreateReliableFixturesService(IFixturesService fixturesService, int maxRetries = 3)
        {
            return new RetryDecorator(fixturesService, maxRetries);
        }
        
        public static RetryDecorator CreateReliableLiveMatchService(ILiveMatchService liveMatchService, int maxRetries = 3)
        {
            return new RetryDecorator(liveMatchService, maxRetries);
        }
    }
}