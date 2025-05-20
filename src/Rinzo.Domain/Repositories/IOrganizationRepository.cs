using Rinzo.Domain.Entities.Common;
namespace Rinzo.Domain.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organization?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void AddOrganization(Organization organization);
    }
}
