using System;
using System.Collections.Generic;

namespace JaySmith.DomainEvents
{
    using System.Web.Mvc;

    public class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks   
        private static List<Delegate> actions;

        public static IDependencyResolver Container { get; set; }

        //Registers a callback for the given domain event   
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        // Clears callbacks passed to Register on the current thread  
        public static void ClearCallbacks()
        {
            actions = null;
        }

        // Raises the given domain event  
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            DependencyResolver.Current.GetServices<Handles<T>>();

            foreach (var handler in Container.GetServices<Handles<T>>())
                handler.Handle(args);

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }

    }
}
