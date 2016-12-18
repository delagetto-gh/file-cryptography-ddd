using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Interfaces
{
    public interface IQueryService
    {
        T Execute<T>(Query<T> qry) where T : class;
    }
}
