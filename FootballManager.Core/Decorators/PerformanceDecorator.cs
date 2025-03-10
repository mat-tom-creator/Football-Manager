namespace FootballManager.Core.Decorators
{
    using Interfaces.Base;
    using System;
    using System.Diagnostics;
    using System.Text;

    public class PerformanceDecorator : ServiceDecorator
    {
        public PerformanceDecorator(IService service) : base(service) { }

        public override string Execute()
        {
            var sb = new StringBuilder();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // Execute the decorated service
            sb.AppendLine(_service.Execute());
            
            stopwatch.Stop();
            sb.AppendLine($"Performance: Execution time was {stopwatch.ElapsedMilliseconds}ms.");
            return sb.ToString();
        }
    }
}