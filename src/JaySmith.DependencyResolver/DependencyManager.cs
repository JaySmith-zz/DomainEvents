using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JaySmith.DependencyResolver
{
    public class DependencyManager
    {
        private readonly Container container;
        private readonly Dictionary<string, Func<object>> args;
        private readonly string name;

        internal DependencyManager(Container container, string name, Type type)
        {
            this.container = container;
            this.name = name;

            ConstructorInfo c = type.GetConstructors().First();
            args = c.GetParameters()
                .ToDictionary<ParameterInfo, string, Func<object>>(
                x => x.Name,
                x => (() => container.services[container.serviceNames[x.ParameterType]]())
                );

            container.services[name] = () => c.Invoke(args.Values.Select(x => x()).ToArray());
        }

        public DependencyManager AsSingleton()
        {
            object value = null;
            Func<object> service = container.services[name];
            container.services[name] = () => value ?? (value = service());
            return this;
        }

        public DependencyManager WithDependency(string parameter, string component)
        {
            args[parameter] = () => container.services[component]();
            return this;
        }

        public DependencyManager WithValue(string parameter, object value)
        {
            args[parameter] = () => value;
            return this;
        }
    }
}
