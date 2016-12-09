using FileCryptography.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts.Requests
{
    [DataContract]
    public class KeyFile : File
    {
        [DataMember]
        public string Email { get; set; }
    }
}
