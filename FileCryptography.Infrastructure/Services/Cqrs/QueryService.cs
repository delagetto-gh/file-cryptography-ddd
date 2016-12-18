using FileCryptography.Infrastructure.Interfaces;
using FileCryptography.Infrastructure.Interfaces.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Services.Cqrs
{
    public class QueryService : IQueryService
    {
        private readonly IContainer iocContainer;

        public QueryService(IContainer iocContainer)
        {
            this.iocContainer = iocContainer;
        }

        public T Execute<T>(Query<T> qry) where T : class
        {
            var queryHdlr = this.iocContainer.Resolve<Query<T>>();
            if (queryHdlr != null)
                return queryHdlr.Execute();
            else
                throw new Exception(String.Format("Cannot resolve query handler for type: {0}", typeof(T)));
        }
    }
}
