using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileCryptography.Framework.Services.Contracts
{
    public interface IServiceResponse
    {
        DateTime TimeStamp { get; }

        bool IsRequestSuccessfull { get; }

        string Error { get; }
    }
}
