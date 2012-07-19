using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaySmith.DomainEvents.StructureMap
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry ()
	    {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                {
                    // Needed for Domain Event Manager to work correctly
                    scan.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
                }
            ));
	    }
    }
}
