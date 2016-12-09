using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    [DataContract]
    public abstract class CryptionRequest : IServiceRequest<string>
    {
        protected CryptionRequest(File file, FileCryptionArgs args)
        {
            this.File = file;
            this.CryptionArgs = args;
            this.TimeStamp = DateTime.Now;
        }

        [DataMember]
        public FileCryptionArgs CryptionArgs { get; set; }

        [DataMember]
        public File File { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }

        public abstract string Execute();
    }
}
