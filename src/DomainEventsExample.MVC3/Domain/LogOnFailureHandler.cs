namespace DomainEventsExample.MVC3.Domain
{
    using System;

    using DomainEventsExample.MVC3.Services.DomainEvents;

    public class LogOnFailureHandler : Handles<LogOnFailEvent>
    {
        public void Handle(LogOnFailEvent args)
        {
            var message = "LogOn Failed: User: " + args.Model.UserName;
        }
    }
}