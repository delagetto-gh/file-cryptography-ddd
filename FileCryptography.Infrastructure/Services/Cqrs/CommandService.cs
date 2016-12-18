using FileCryptography.Domain.Interfaces.Commands;
using FileCryptography.Domain.Interfaces.Repositories;
using FileCryptography.Infrastructure.Interfaces;
using FileCryptography.Infrastructure.Interfaces.CommandHandler;
using FileCryptography.Infrastructure.Interfaces.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FileCryptography.Infrastructure.Services.Cqrs
{
    public class CommandService : ICommandService
    {
        private readonly IContainer iocContainer;

        public CommandService(IContainer repo)
        {
            this.iocContainer = repo;
        }

        public void Execute<T>(T cmd) where T : Command
        {
            var cmdHandler = this.iocContainer.Resolve<ICommandHandler<T>>();
            if (cmdHandler != null)
            {
                using (var trx = new TransactionScope())
                {
                    cmdHandler.Handle(cmd);
                    trx.Complete();
                }
            }
            else
                throw new Exception(String.Format("Cannot resolve command handler for type: {0}", typeof(T)));

        }
    }
}
