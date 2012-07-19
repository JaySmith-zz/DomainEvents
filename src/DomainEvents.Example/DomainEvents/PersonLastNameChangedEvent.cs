using DomainEvents.Example.Domain;
using JaySmith.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Example.DomainEvents
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
