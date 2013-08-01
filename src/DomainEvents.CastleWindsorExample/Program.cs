using System;
using DomainEvents.CastleWindsorExample.DomainEvents;
using JaySmith.DomainEvents;

namespace DomainEvents.CastleWindsorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            var events = Bootstrapper.Container.ResolveAll<IDomainEventHandler<PersonLastNameChangedEvent>>();

            //var handlers = ObjectFactory.GetAllInstances(typeof(IDomainEventHandler<PersonLastNameChangedEvent>));

            var application = Bootstrapper.Container.Resolve<IDemoApplication>();
            application.Run();

            Console.Read();
        }
    }
}
