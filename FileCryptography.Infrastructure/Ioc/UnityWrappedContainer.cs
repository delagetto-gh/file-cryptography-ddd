using FileCryptography.Domain.Interfaces.Events;
using FileCryptography.Infrastructure.Interfaces;
using FileCryptography.Infrastructure.Interfaces.Ioc;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Ioc
{
    public class UnityWrappedContainer : IContainer, IEventDispatcher
    {
        private readonly IUnityContainer underlyingContainer;

        public UnityWrappedContainer(IUnityContainer unityContainer)
        {
            this.underlyingContainer = unityContainer;
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return this.underlyingContainer.ResolveAll<T>();
        }

        public T Resolve<T>()
        {
            return this.underlyingContainer.Resolve<T>();
        }

        public void Subscribe<T>(Action<T> eventHandle) where T : DomainEvent
        {
            // NOP
        }

        public void Dispatch<T>(T @event) where T : DomainEvent
        {
            IEnumerable<IEventHandler<T>> eventHdlrs = this.ResolveAll<IEventHandler<T>>();
            foreach (var hlr in eventHdlrs)
            {
                hlr.Handle(@event);
            }
        }
    }
}
