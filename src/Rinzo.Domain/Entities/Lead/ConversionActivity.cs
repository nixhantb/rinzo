

namespace Rinzo.Domain.Entities.Lead
{
    public class ConversionActivity : LeadActivity
    {
        public ConversionActivity(
            Guid id,
            Guid leadId,
            Guid createdBy,
            Guid ContactId
           ) : base(id, leadId, createdBy)
        {
            ContactId = ContactId;
        }
        public Guid ContactId { get; private set; }
    }
}
