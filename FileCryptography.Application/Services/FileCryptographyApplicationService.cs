using FileCryptography.Application.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Commands;
using FileCryptography.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Application.Services
{
    public class FileCryptographyApplicationService : IApplicationService
    {
        private readonly ICommandService cmdSvc;
        private readonly IQueryService querySvc;

        public FileCryptographyApplicationService(ICommandService cmdSvc, IQueryService querySvc)
        {
            this.cmdSvc = cmdSvc;
            this.querySvc = querySvc;
        }

        public void Execute<T>(T cmd) where T : Command
        {
            this.cmdSvc.Execute(cmd);
        }

        public T Execute<T>(Query<T> qry) where T : class
        {
            return this.querySvc.Execute(qry);
        }
    }
}
