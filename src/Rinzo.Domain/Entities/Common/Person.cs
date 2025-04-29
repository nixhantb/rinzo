using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;
using Rinzo.Domain.ValueObjects;

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
        /// <param name="phone">Phone number of the person</param>
        internal Person(Guid id, Salutation? salutationType, FirstName firstName, LastName lastName, Email email, Phone phone) : base(id)
        {
            SalutationType = salutationType;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public Salutation? SalutationType { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }

        public static Person CreatePerson(Salutation? salutationType, FirstName firstName, LastName lastName, Email email, Phone phone)
        {
            return new Person(Guid.NewGuid(), salutationType, firstName, lastName, email, phone);
        }


    }
}
