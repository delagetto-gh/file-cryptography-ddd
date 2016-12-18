using System.Collections.Generic;

namespace FileCryptography.Infrastructure.Interfaces.Ioc
{
    public interface IContainer
    {
        IEnumerable<T> ResolveAll<T>();

        T Resolve<T>();
    }
}
