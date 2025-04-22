
using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities.Contact
{
    /// <summary>
    /// Sealed class which means that no class can extend or subclass Contact
    /// </summary>
    public sealed class Contact : Entity
    {
        /// <summary>
        /// Private constructor used for controlled instantiation via factory methods or persistence.
        /// </summary>
        /// <param name="id">Unique identifier of the contact</param>
        /// <param name="firstName">First name of the contact</param>
        /// <param name="lastName">Last name of the contact</param>
        /// <param name="email">Email address of the contact</param>
        /// <param name="phoneNumber">Phone number of the contact</param>
        /// <param name="genderType">Gender of the contact</param>
        /// <param name="salutationName">Salutation (e.g., Mr., Ms., Dr.)</param>
        /// <param name="mailingAddress">Mailing address (value object)</param>
        private Contact(
            Guid id, 
            string? firstName, 
            string lastName, 
            string email, 
            string phoneNumber, 
            string jobTitle,
            string organization,
            Gender genderType, 
            Salutation salutationType, 
            Address mailingAddress) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            JobTitle = jobTitle;
            Organization = organization;
            GenderType = genderType;
            SalutationType = salutationType;
            MailingAddress = mailingAddress;
        }
        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }   
        public string PhoneNumber { get; private set; }
        public string JobTitle { get; private set; }
        public string Organization { get; private set; }
        public Gender GenderType { get; private set; }
        public Salutation SalutationType { get; private set; }
        public Address MailingAddress { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
