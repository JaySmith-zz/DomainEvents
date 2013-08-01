using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace DomainEvents.CastleWindsorExample
{
    public static class Bootstrapper
    {
        public static IWindsorContainer Container { get; set; }
        public static void Initialize()
        {
            // Create the container
            Container = new WindsorContainer();

            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));

            // Register the kernel and container in case an installer needs it
            Container.Register(
                Component.For<IKernel>().Instance(Container.Kernel),
                Component.For<IWindsorContainer>().Instance(Container)
                );

            // Search for an use all installers in this application.
            Container.Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory)));
            
            //    scan.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
        }
    }
}