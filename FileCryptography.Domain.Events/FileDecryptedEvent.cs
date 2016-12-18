using FileCryptography.Domain.Interfaces.Common;
using FileCryptography.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Domain.Events
{
    public class FileDecryptedEvent : DomainEvent
    {
        public FileDecryptedEvent(Guid aggregateId, FileInfo decryptedFile)
            : base(aggregateId)
        {
            this.DecryptedFile = decryptedFile;
        }

        public FileInfo DecryptedFile { get; set; }
    }
}
