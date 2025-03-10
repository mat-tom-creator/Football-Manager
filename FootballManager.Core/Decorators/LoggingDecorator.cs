namespace FootballManager.Core.Decorators
{
    using Interfaces.Base;
    using System;
    using System.Text;

    public class LoggingDecorator : ServiceDecorator
    {
        public LoggingDecorator(IService service) : base(service) { }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Logging: Service execution started.");
            
            // Execute the decorated service
            sb.AppendLine(_service.Execute());
            
            sb.AppendLine("Logging: Service execution completed.");
            return sb.ToString();
        }
    }
}