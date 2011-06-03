namespace DomainEventsExample.MVC3.Services.DomainEvents
{
    public interface Handles<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}