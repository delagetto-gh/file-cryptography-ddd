using FileCryptography.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces.CommandHandler
{
    public interface ICommandHandler<T> where T : Command
    {
        void Handle(T cmd);
    }
}
