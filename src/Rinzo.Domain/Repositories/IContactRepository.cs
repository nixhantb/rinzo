
using Rinzo.Domain.Entities.Contacts;
namespace Rinzo.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void AddContact (Contact contact);  
    }
}
