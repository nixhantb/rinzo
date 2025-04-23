using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities.Common
{
    public class Person : Entity
    {
        /// <summary>
        /// Private constructor used for controlled instantiation via factory methods or persistence.
        /// </summary>
        /// <param name="id">Unique identifier of the person</param>
        /// <param name="salutationName">Salutation (e.g., Mr., Ms., Dr.)</param>
        /// <param name="firstName">First name of the person</param>
        /// <param name="lastName">Last name of the person</param>
        /// <param name="email">Email address of the person</param>
        /// <param name="phoneNumber">Phone number of the person</param>
        internal Person(Guid id, Salutation? salutationType, string? firstName, string lastName, string? email, string? phoneNumber) : base(id)
        {
            SalutationType = salutationType;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Salutation? SalutationType { get; private set; }
        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }

        public static Person CreatePerson(Salutation? salutationType, string? firstName, string lastName, string? email, string? phoneNumber)
        {
            return new Person(Guid.NewGuid(), salutationType, firstName, lastName, email, phoneNumber);
        }


    }
}
