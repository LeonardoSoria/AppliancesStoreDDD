using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();

        Task<Client> GetClientById(Guid clientId);

        Task Insert(Client client);

        Task<Client> Update(Client client);

        Task Delete(Guid clientId);
    }
}
