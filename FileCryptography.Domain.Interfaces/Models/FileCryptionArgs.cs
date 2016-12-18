using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Domain.Models
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
