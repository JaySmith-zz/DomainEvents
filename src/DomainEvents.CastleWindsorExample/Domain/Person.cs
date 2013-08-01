using DomainEvents.CastleWindsorExample.DomainEvents;
using JaySmith.DomainEvents;

namespace DomainEvents.CastleWindsorExample.Domain
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this._lastName = lastName;
        }

        public string FirstName { get; set; }

        private string _lastName;
        public string LastName 
        { 
            get
            {
                return _lastName;
            }
            set
            {
                var oldValue = _lastName;
                _lastName = value;

                //Raise LastNameChangedEvent
                var lastNameChangedEvent = new PersonLastNameChangedEvent(this, oldValue, value);
                DomainEventManager.Raise(lastNameChangedEvent);
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
