namespace DomainEventsExample.MVC3.Domain
{
    using System;

    using DomainEventsExample.MVC3.Models;
    using DomainEventsExample.MVC3.Services.DomainEvents;

    public class LogOnSuccessEvent : IDomainEvent
    {
        public LogOnSuccessEvent(LogOnModel model)
        {
            this.Model = model;
        }

        public LogOnModel Model { get; set; }
    }

    public class LogOnFailEvent : IDomainEvent
    {
        public LogOnFailEvent(LogOnModel model)
        {
            Model = model;
        }

        public LogOnModel Model { get; set; }
    }
}