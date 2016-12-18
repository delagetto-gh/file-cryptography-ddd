using FileCryptography.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Interfaces.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// Really shouldnt be using T generics here, on a generic repository as it leaks persistence specifcs"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        Task<T> Get<T>(Guid aggregateId) where T : AggregateRoot;

        Task Save<T>(T aggregate) where T : AggregateRoot;
    }
}
