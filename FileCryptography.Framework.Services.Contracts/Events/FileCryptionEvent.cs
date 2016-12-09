using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    [DataContract]
    public class FileCryptionEvent
    {
        [DataMember]
        public File File { get; set; }

        [DataMember]
        public string ExecutedCommand { get; set; }
    }
}
