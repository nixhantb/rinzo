using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum LeadStatus
    {
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "Contacted")]
        Contacted = 2,

        [Display(Name = "Qualified")]
        Qualified = 3,

        [Display(Name = "Unqualified")]
        Unqualified = 4,

        [Display(Name = "Converted")]
        Converted = 5,

        [Display(Name = "Disqualified")]
        Disqualified = 6,

        [Display(Name = "Follow Up")]
        FollowUp = 7,

        [Display(Name = "Lost")]
        Lost = 8,

        [Display(Name = "Nurturing")]
        Nurturing = 9,

        [Display(Name = "Recycled")]
        Recycled = 10,

        [Display(Name = "Archived")]
        Archived = 11,

        [Display(Name = "Closed")]
        Closed = 12
    }
}
