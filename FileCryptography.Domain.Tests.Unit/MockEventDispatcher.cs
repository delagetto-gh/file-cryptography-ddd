using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Tests.Unit
{
    internal class MockEventDispatcher : IEventDispatcher
    {
        internal List<DomainEvent> Events { get; private set; }

        public MockEventDispatcher()
        {
            this.Events = new List<DomainEvent>();
        }

        public void Subscribe<T>(Action<T> eventHandle) where T : DomainEvent
        {
            //NOP
        }

        public void Dispatch<T>(T @event) where T : DomainEvent
        {
            this.Events.Add(@event);
        }
    }
}
