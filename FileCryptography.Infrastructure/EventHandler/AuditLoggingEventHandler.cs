using FileCryptography.Domain.Events;
using FileCryptography.Infrastructure.Interfaces;
using FileCryptography.Infrastructure.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.EventHandler
{
    public class AuditLoggingEventHandler : IEventHandler<FileDecryptedEvent>,
                                            IEventHandler<KeyPairGeneratedEvent>
    {
        private readonly ILogger underlyingLoggerSystem;

        public AuditLoggingEventHandler(ILogger physicalLog)
        {
            this.underlyingLoggerSystem = physicalLog;
        }

        public void Handle(KeyPairGeneratedEvent @event)
        {
            this.underlyingLoggerSystem.Log(String.Format("EventType: {0}. User {1}", typeof(KeyPairGeneratedEvent), @event.Username));
        }

        public void Handle(FileDecryptedEvent @event)
        {
            this.underlyingLoggerSystem.Log(String.Format("EventType: {0}. User {1}. Decryptedfile {1}", typeof(FileDecryptedEvent), @event.Username, @event.DecryptedFile.FileName));
            this.underlyingLoggerSystem.Log(String.Format("Content: {0}", typeof(FileDecryptedEvent), @event.DecryptedFile.Content));
        }
    }
}
