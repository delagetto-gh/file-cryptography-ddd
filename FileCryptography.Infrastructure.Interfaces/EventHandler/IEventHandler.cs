using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces
{
    public interface IEventHandler<T> where T : DomainEvent
    {
        void Handle(T @event);
    }
}
