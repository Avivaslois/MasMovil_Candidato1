using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.UnitOfWork
{
    public interface InterfaceUnitOfWork
    {
        InterfaceRepository<T> GetRepository<T>() where T : class;
    }
}
