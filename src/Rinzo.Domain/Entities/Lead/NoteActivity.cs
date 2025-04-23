namespace Rinzo.Domain.Entities.Lead
{
    public sealed class NoteActivity : LeadActivity
    {
        public string Content { get; private set; }
        public NoteActivity(Guid id, Guid leadId, Guid createdBy, string content) : base(id, leadId, createdBy)
        {
            Content = content;
        }
    }
}
