using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.ServiceLocatorAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaySmith.DomainEvents.StructureMap
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry() 
        {
            //Scan(scan => {
            //    scan.AssemblyContainingType<IDomainEvent>();
            //    scan.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
            //});

            try
            {
                var locator = ServiceLocator.Current;
            }
            catch (Exception)
            {
                ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
            }
        }
    }
}
