namespace FootballManager.Core.Decorators
{
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CachingDecorator : ServiceDecorator
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();
        private readonly string _cacheKey;
        private readonly TimeSpan _cacheDuration;
        private DateTime _lastCacheTime = DateTime.MinValue;

        public CachingDecorator(IService service, string cacheKey = "default", TimeSpan? cacheDuration = null) 
            : base(service)
        {
            _cacheKey = cacheKey;
            _cacheDuration = cacheDuration ?? TimeSpan.FromMinutes(5); // Default 5 minutes
        }

        public override string Execute()
        {
            // Check if cache is valid
            if (_cache.TryGetValue(_cacheKey, out string cachedResult) && 
                DateTime.Now - _lastCacheTime < _cacheDuration)
            {
                return $"[Cache Hit] Returning cached result:\n{cachedResult}";
            }

            // Execute the decorated service
            string result = _service.Execute();
            
            // Cache the result
            _cache[_cacheKey] = result;
            _lastCacheTime = DateTime.Now;
            
            return $"[Cache Miss] Caching and returning fresh result:\n{result}";
        }

        // Method to manually clear the cache
        public void ClearCache()
        {
            _cache.Clear();
            _lastCacheTime = DateTime.MinValue;
        }
    }
}