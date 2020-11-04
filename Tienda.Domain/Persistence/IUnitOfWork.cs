using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Distribucion.Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
