using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IJobFormRepository
    {
        Task<List<JobForm>> GetJobForms();

        Task<JobForm> GetJobFormById(Guid jobFormId);

        Task Insert(JobForm jobForm);

        Task<JobForm> Update(Guid JobFormId, JobForm jobForm);

        Task Delete(Guid jobFormId);
    }
}
