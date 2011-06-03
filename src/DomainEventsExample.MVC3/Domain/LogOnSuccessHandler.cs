namespace DomainEventsExample.MVC3.Domain
{
    using DomainEventsExample.MVC3.Services.DomainEvents;

    public class LogOnSuccessHandler : Handles<LogOnSuccessEvent>
    {
        public void Handle(LogOnSuccessEvent args)
        {
            // Do someting interesting

            var message = "LogOn Success: User: " + args.Model.UserName;
        }
    }
}