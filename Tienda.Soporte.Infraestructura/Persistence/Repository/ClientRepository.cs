using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Persistence;

namespace Tienda.Soporte.Infraestructura.Persistence.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid clientId)
        {
            Client obj = await _context.Clients.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
            _context.Clients.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(Guid clientId)
        {
            Client obj = await _context.Clients.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clientsList = await _context.Clients.ToListAsync();
            return clientsList;
        }

        public async Task Insert(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<Client> Update(Client client)
        {
            Client obj = await _context.Clients.Where(x => x.ClientId == client.ClientId).FirstOrDefaultAsync();
            _context.Entry(obj).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
