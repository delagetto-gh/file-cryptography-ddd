using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces.Logging
{
    public interface ILogger
    {
        Task Log(string message);
    }
}
