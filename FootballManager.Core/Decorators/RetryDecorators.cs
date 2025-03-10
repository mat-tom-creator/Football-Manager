namespace FootballManager.Core.Decorators
{
    using Interfaces.Base;
    using System;
    using System.Text;
    using System.Threading;

    public class RetryDecorator : ServiceDecorator
    {
        private readonly int _maxRetries;
        private readonly TimeSpan _delay;

        public RetryDecorator(IService service, int maxRetries = 3, TimeSpan? delay = null) 
            : base(service)
        {
            if (maxRetries < 1)
                throw new ArgumentException("Max retries must be at least 1", nameof(maxRetries));
            
            _maxRetries = maxRetries;
            _delay = delay ?? TimeSpan.FromMilliseconds(500); // Default 500ms delay
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            Exception lastException = null;

            for (int attempt = 1; attempt <= _maxRetries; attempt++)
            {
                try
                {
                    // Attempt to execute the service
                    string result = _service.Execute();
                    
                    // If we got here, it succeeded
                    if (attempt > 1)
                    {
                        sb.AppendLine($"[Retry] Succeeded on attempt {attempt} after {attempt - 1} failures.");
                    }
                    
                    sb.AppendLine(result);
                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    sb.AppendLine($"[Retry] Attempt {attempt} failed with error: {ex.Message}");
                    
                    // Don't delay on the last attempt
                    if (attempt < _maxRetries)
                    {
                        Thread.Sleep(_delay);
                    }
                }
            }

            // If we get here, all retries failed
            sb.AppendLine($"[Retry] All {_maxRetries} attempts failed. Last error: {lastException?.Message}");
            throw new Exception($"Operation failed after {_maxRetries} attempts", lastException);
        }
    }
}