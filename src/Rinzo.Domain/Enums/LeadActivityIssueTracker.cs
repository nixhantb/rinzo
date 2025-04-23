using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum LeadActivityIssueTracker
    {
        [Display(Name = "Backlog")]
        Backlog = 1,

        [Display(Name = "To Do")]
        Todo = 2,

        [Display(Name = "In Progress")]
        InProgress = 3,

        [Display(Name = "Done")]
        Done = 4,

        [Display(Name = "Cancelled")]
        Cancelled = 5
    }
}
