using System.Web.Mvc;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DomainEventsExample.MVC3.App_Start.StructuremapMvc), "Start")]

namespace DomainEventsExample.MVC3.App_Start {
    public static class StructuremapMvc {
        public static void Start()
        {
            var container = IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}