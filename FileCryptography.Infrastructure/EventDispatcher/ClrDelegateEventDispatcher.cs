using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.EventDispatcher
{
    public class ClrDelegateEventDispatcher : IEventDispatcher
    {
        private readonly Dictionary<Type, List<Delegate>> subscribers;

        public ClrDelegateEventDispatcher()
        {
            this.subscribers = new Dictionary<Type, List<Delegate>>();
        }

        public void Subscribe<T>(Action<T> @eventHandle) where T : DomainEvent
        {
            if (subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)].Add(@eventHandle);
            }
        }

        public void Dispatch<T>(T @event) where T : DomainEvent
        {
            if (subscribers.ContainsKey(typeof(T)))
            {
                foreach (var sub in subscribers[typeof(T)])
                    ((Action<T>)sub)(@event);
            }
        }
    }
}
