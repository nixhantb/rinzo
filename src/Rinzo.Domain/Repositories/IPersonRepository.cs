using Rinzo.Domain.Entities.Common;
namespace Rinzo.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void AddPerson(Person person);
    }
}
