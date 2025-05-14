using System.ComponentModel.DataAnnotations;


namespace Rinzo.Domain.Enums
{
    public enum LeadStatus
    {

        [Display(Name = "Converted")]
        Converted = 0,
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "Contacted")]
        Contacted = 2,

        [Display(Name = "Qualified")]
        Qualified = 3,

        [Display(Name = "Unqualified")]
        Unqualified = 4,

        [Display(Name = "Nurturing")]
        Nurturing = 5,

        [Display(Name = "Junk")]
        Junk = 6
       



    }
}
