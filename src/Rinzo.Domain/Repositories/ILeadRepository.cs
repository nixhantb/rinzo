
using Rinzo.Domain.Entities.Lead;
namespace Rinzo.Domain.Repositories
{
    public interface ILeadRepository
    {
        Task<Lead?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void AddLead(Lead lead);
    }
    
}
