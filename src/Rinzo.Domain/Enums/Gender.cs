using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Unknown")]
        Unknown = 0,

        [Display(Name = "Female")]
        Female = 1,

        [Display(Name = "Male")]
        Male = 2,

        [Display(Name = "Transgender")]
        Transgender = 3,

        [Display(Name = "Non-Binary")]
        NonBinary = 4,

        [Display(Name = "Other")]
        Other = 5
    }
}
