using FileCryptography.Infrastructure.Interfaces.Ioc;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCryptography.Infrastructure.Ioc
{
    public class UnityWrappedContainer : IContainer
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
    }
}
