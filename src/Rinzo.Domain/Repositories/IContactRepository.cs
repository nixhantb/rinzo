
using Rinzo.Domain.Entities.Contacts;
namespace Rinzo.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
