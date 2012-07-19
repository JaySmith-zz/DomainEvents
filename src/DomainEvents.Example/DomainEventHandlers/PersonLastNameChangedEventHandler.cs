using DomainEvents.Example.DomainEvents;
using JaySmith.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
