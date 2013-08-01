using DomainEvents.CastleWindsorExample.Domain;

namespace DomainEvents.CastleWindsorExample
{
    public interface IDemoApplication
    {
        void Run();
    }

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
