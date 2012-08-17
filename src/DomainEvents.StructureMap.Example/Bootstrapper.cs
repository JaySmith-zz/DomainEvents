using JaySmith.DomainEvents;
using StructureMap;

namespace DomainEvents.Example
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AssembliesFromApplicationBaseDirectory();
                scan.LookForRegistries();
                
                // Would like to remove and do in StructureMapRegistry
                scan.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
            }));
        }
    }
}