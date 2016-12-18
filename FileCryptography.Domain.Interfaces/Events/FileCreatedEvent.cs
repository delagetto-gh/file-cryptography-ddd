using FileCryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Events
{
    public class FileCreatedEvent : DomainEvent
    {
        public File File { get; set; }
    }
}
