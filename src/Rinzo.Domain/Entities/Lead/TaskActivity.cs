using Rinzo.Domain.Entities.Lead;
using Rinzo.Domain.Enums;

internal class TaskActivity : LeadActivity
{
    public TaskActivity(
        Guid id,
        string? title,
        string? description,
        LeadActivityIssueTracker issueTracker,
        DateTime createdOn,
        LeadActivityPriority priority,
        Guid leadId,
        Guid createdBy)
        : base(id, leadId, createdBy)
    {
        Title = title;
        Description = description;
        IssueTracker = issueTracker;
        CreatedOn = createdOn;
        LeadActivityPriority = priority;
    }

    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public LeadActivityIssueTracker IssueTracker { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public LeadActivityPriority LeadActivityPriority { get; private set; }

    public static LeadActivity CreateTaskActivity(
        Guid leadId,
        Guid createdBy,
        string? title,
        string? description,
        DateTime createdOn)
    {
        return new TaskActivity(
            Guid.NewGuid(),
            title,
            description,
            LeadActivityIssueTracker.Backlog,
            createdOn,
            LeadActivityPriority.Low,
            leadId,
            createdBy
        );
    }
}
