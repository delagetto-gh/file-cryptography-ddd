using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces
{
    public abstract class Query<TQueryResult> where TQueryResult : class
    {
        public abstract TQueryResult Execute();
    }
}
