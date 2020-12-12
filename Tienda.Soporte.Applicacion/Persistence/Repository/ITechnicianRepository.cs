using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface ITechnicianRepository
    {
        Task<List<Technician>> GetTechnicians();

        Task<Technician> GetTechnicianById(Guid technicianId);

        Task Insert(Technician technician);

        Task<Technician> Update(Guid technicianId, Technician technician);

        Task Delete(Guid technicianId);
    }
}
