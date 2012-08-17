using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaySmith.DependencyResolver
{
    public class Container
    {
        protected readonly Dictionary<string, Func<object>> services = new Dictionary<string, Func<object>>();
        protected readonly Dictionary<Type, string> serviceNames = new Dictionary<Type, string>();

        public DependencyManager Register<S, C>() where C : S
        {
            return Register<S, C>(Guid.NewGuid().ToString());
        }

        public DependencyManager Register<S, C>(string name) where C : S
        {
            if (!serviceNames.ContainsKey(typeof(S)))
            {
                serviceNames[typeof(S)] = name;
            }
            return new DependencyManager(this, name, typeof(C));
        }

        public T Resolve<T>(string name) where T : class
        {
            return (T)services[name]();
        }

        public T Resolve<T>() where T : class
        {
            return Resolve<T>(serviceNames[typeof(T)]);
        }
    } 
}
