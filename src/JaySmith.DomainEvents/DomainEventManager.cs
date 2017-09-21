using System;
using System.Linq;

namespace JaySmith.DomainEvents
{
    public class DomainEventManager
    {
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            var searchType = typeof(IDomainEventHandler<>).MakeGenericType(typeof(T));

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var handlers = from t in assembly.GetTypes()
                               where t.GetInterfaces().Contains(searchType)
                                        && t.GetConstructor(Type.EmptyTypes) != null
                               select Activator.CreateInstance(t) as IDomainEventHandler<T>;

                foreach (var handler in handlers)
                    handler.Handle(args);

            }
        }
    }
}
