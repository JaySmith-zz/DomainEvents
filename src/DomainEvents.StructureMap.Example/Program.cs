using DomainEvents.Example.DomainEvents;
using JaySmith.DomainEvents;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEvents.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            //var handlers = ObjectFactory.GetAllInstances(typeof(IDomainEventHandler<PersonLastNameChangedEvent>));

            var application = ObjectFactory.GetInstance<DemoApplication>();
            application.Run();

            Console.Read();
        }
    }
}
