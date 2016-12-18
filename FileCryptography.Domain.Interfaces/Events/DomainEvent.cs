using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Interfaces.Events
{
    public abstract class DomainEvent
    {
        protected DomainEvent(Guid aggregateId)
        {
            this.AggregateId = aggregateId;
            this.Created = DateTimeOffset.Now;
            this.Username = Environment.UserDomainName;
        }

        public DateTimeOffset Created { get; set; }

        public string Username { get; set; }

        public Guid AggregateId { get; private set; }
    }
}
