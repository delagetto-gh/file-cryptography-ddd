using FileCryptography.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces
{
    public interface ICommandService
    {
        void Execute<T>(T cmd) where T : Command;
    }
}
