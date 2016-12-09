using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FileCryptography.Framework.Services.Contracts.Requests;

namespace FileCryptography.Framework.Services.Contracts
{
    [DataContract]
    public class FileCryptionArgs
    {
        [DataMember]
        public KeyFile PassPhrase { get; set; }

        [DataMember]
        public KeyFile PrivateKey { get; set; }

        [DataMember]
        public KeyFile PublicKey { get; set; }
    }
}
