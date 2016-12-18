using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Interfaces.Models
{
    public abstract class AggregateRoot
    {
        public AggregateRoot()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
