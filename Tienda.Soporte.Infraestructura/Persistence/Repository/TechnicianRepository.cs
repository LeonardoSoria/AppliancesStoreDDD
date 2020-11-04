using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence.Repository;

namespace Tienda.Soporte.Infraestructura.Persistence.Repository
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnicianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Delete(Guid technicianId)
        {
            throw new NotImplementedException();
        }

        public async Task<Technician> GetTechnicianById(Guid technicianId)
        {
            Technician obj = await _context.Technicians.Where(x => x.TechnicianId == technicianId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task<List<Technician>> GetTechnicians()
        {
            List<Technician> technicianList = await _context.Technicians.ToListAsync();
            return technicianList;
        }

        public async Task Insert(Technician technician)
        {
            await _context.Technicians.AddAsync(technician);
        }

        public Task<Technician> Update(Guid technicianId, Technician technician)
        {
            throw new NotImplementedException();
        }
    }
}
