using System;
using DomainEvents.CastleWindsorExample.DomainEvents;
using JaySmith.DomainEvents;

namespace DomainEvents.CastleWindsorExample.DomainEventHandlers
{
    public class PersonLastNameChangedEventHandler : IDomainEventHandler<PersonLastNameChangedEvent>
    {
        public void Handle(PersonLastNameChangedEvent args)
        {
 	        Console.WriteLine("Lastname changed from {0} to {1}", args.OldValue, args.NewValue);
        }
    }
}
