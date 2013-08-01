using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace DomainEvents.CastleWindsorExample
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDemoApplication>().ImplementedBy<DemoApplication>()

                //AllTypes.FromAssemblyInDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory))
                //.BasedOn(typeof(IDomainEventHandler<>))
                //.WithService.Base()
               );
        }
    }
}