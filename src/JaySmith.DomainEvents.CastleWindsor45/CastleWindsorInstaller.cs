using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;

namespace JaySmith.DomainEvents.Castle
{
    public class CastleWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            try
            {
                container.Register(
                    AllTypes.FromAssemblyInDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory))
                            .BasedOn(typeof (IDomainEventHandler<>))
                            .WithService.Base()
                    );

                var locator = ServiceLocator.Current;
            }
            catch (Exception)
            {
                ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            }
        }
    }
}
