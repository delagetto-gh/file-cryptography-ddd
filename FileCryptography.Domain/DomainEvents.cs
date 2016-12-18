using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain
{
    public static class DomainEvents
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Publish<T>(T @event) where T : DomainEvent
        {
            Dispatcher.Dispatch(@event);
        }
    }
}
