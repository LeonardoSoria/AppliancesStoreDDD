using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Soporte.Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
