namespace JaySmith.DomainEvents.StructureMap
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using global::StructureMap;

    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType) as IEnumerable<object>;
        }
    }
}
