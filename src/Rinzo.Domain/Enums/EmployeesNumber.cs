using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum EmployeesNumber
    {
        [Display(Name = "1-100")]
        OneToHundred,

        [Display(Name = "100-200")]
        HundredToTwoHundred,

        [Display(Name = "200-500")]
        TwoHundredToFiveHundred,

        [Display(Name = "500-1000")]
        FiveHundredToThousand,

        [Display(Name = "1000+")]
        ThousandPlus
    }
}
