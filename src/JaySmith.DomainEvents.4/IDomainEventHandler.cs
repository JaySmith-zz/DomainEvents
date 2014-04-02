namespace JaySmith.DomainEvents
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}