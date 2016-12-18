using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Interfaces.Events
{
    public interface IEventDispatcher
    {
        void Subscribe<T>(Action<T> @eventHandle) where T : DomainEvent;

        void Dispatch<T>(T @event) where T : DomainEvent;
    }
}
