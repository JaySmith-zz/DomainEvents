using System;
using DomainEvents.Example.DomainEvents;
using JaySmith.DomainEvents;

namespace DomainEvents.Example.DomainEventHandlers
{
    public class PersonLastNameChangedEventHandler : IDomainEventHandler<PersonLastNameChangedEvent>
    {
        public void Handle(PersonLastNameChangedEvent args)
        {
 	        Console.WriteLine("Lastname changed from {0} to {1}", args.OldValue, args.NewValue);
        }
    }
}
