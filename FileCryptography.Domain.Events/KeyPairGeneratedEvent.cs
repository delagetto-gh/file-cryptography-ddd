using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Events
{
    public class KeyPairGeneratedEvent : DomainEvent
    {
        public KeyPairGeneratedEvent(Guid aggregateId)
            : base(aggregateId)
        {
        }
    }
}
