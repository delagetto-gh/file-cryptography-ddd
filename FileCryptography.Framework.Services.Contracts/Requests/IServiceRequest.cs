using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    public interface IServiceRequest<T>
    {
        [DataMember]
        DateTime TimeStamp { get; }

        T Execute();
    }
}
