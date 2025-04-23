using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities.Common
{
    public class Organization : Entity
    {
        internal Organization(
            string? organizationName,
            EmployeesNumber? employeeNumbers,
            decimal? annualRevenue,
            string? website,
            Guid id
        ) : base(id)
        {
            OrganizationName = organizationName;
            EmployeesNumbers = employeeNumbers;
            Website = website;
            AnnualRevenue = annualRevenue;
        }

        public string? OrganizationName { get; private set; }

        public EmployeesNumber? EmployeesNumbers { get; private set; }

        public decimal? AnnualRevenue { get; private set; }

        public string? Website { get; private set; }

       
        public static Organization Create(
            string? organizationName,
            EmployeesNumber? employeeNumbers,
            decimal? annualRevenue,
            string? website
        )
        {

            return new Organization(
                organizationName,
                employeeNumbers,
                annualRevenue,
                website,
                Guid.NewGuid() 
            );
        }
    }
}
