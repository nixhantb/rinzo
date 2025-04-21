using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum Salutation
    {
        [Display(Name = "Mr.")]
        Mr = 0,

        [Display(Name = "Mrs.")]
        Mrs = 1,

        [Display(Name = "Miss")]
        Miss = 2,

        [Display(Name = "Ms.")]
        Ms = 3,

        [Display(Name = "Dr.")]
        Dr = 4,

        [Display(Name = "Prof.")]
        Prof = 5,

        [Display(Name = "Rev.")]
        Rev = 6,

        [Display(Name = "Other")]
        Other = 7
    }
}
