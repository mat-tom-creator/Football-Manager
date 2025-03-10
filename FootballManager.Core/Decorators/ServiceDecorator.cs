namespace FootballManager.Core.Decorators
{
    using Interfaces.Base;
    using System;

    public abstract class ServiceDecorator : IService
    {
        protected readonly IService _service;

        protected ServiceDecorator(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public abstract string Execute();
    }
}