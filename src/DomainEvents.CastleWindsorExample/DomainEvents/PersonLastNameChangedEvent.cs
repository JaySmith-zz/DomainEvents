using DomainEvents.CastleWindsorExample.Domain;
using JaySmith.DomainEvents;

namespace DomainEvents.CastleWindsorExample.DomainEvents
{
    public class PersonLastNameChangedEvent : IDomainEvent
    {
        public Person Person { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public PersonLastNameChangedEvent(Person person, string oldValue, string newValue )
    	{
            this.Person = person;
            this.OldValue = oldValue;
            this.NewValue = newValue;
	    }
    }
}
