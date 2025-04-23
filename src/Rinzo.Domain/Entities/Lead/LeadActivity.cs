using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities.Lead
{
    public abstract class LeadActivity : Entity
    {
        protected LeadActivity(Guid id, Guid leadId, Guid createdBy) : base(id)
        {
            LeadId = leadId;
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;

        }

        public Guid LeadId { get; private set; }
        public Guid CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
