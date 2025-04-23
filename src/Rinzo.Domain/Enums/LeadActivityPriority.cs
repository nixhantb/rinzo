using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum LeadActivityPriority
    {
        [Display(Name = "Low")]
        Low = 1,

        [Display(Name = "Medium")]
        Medium = 2,

        [Display(Name = "High")]
        High = 3,

        [Display(Name = "Critical")]
        Critical = 4
    }
}
