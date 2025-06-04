

namespace Rinzo.Domain.Primitives
{
    // it helps to create a trasactional boundaries
    internal class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) 
            : base(id)
        {
        }
    }
}
