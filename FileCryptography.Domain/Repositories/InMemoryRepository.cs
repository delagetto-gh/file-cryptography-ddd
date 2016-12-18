using FileCryptography.Domain.Interfaces.Models;
using FileCryptography.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCryptography.Domain.Repositories
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<Guid, AggregateRoot> arRepo;

        public InMemoryRepository()
        {
            this.arRepo = new Dictionary<Guid, AggregateRoot>();
        }

        public async Task<T> Get<T>(Guid aggregateId) where T : AggregateRoot
        {
            if (this.arRepo.ContainsKey(aggregateId))
                return (T)this.arRepo[aggregateId];
            else
                return default(T);
        }

        public async Task Save<T>(T aggregate) where T : AggregateRoot
        {
            if (this.arRepo.ContainsKey(aggregate.Id))
                this.arRepo[aggregate.Id] = aggregate;
            else
                this.arRepo.Add(aggregate.Id, aggregate);
        }
    }
}
