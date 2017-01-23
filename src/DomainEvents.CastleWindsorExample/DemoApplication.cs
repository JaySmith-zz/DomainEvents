using DomainEvents.CastleWindsorExample.Domain;

namespace DomainEvents.CastleWindsorExample
{
    public class DemoApplication : IDemoApplication
    {
        public void Run()
        {
            var person = new Person("Kristina", "Parker");
            
            // Change Last Name
            person.LastName = "Smith";
        }
    }
}
