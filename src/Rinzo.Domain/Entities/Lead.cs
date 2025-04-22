using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities
{
    public sealed class Lead : Entity
    {
        /// <summary>
        /// Private constructor used for controlled instantiation via factory methods or persistence.
        /// </summary>
        /// <param name="id">Unique identifier of the lead</param>
        /// <param name="firstName">First name of the lead</param>
        /// <param name="lastName">Last name of the lead</param>
        /// <param name="email">Email address of the lead</param>
        /// <param name="phoneNumber">Phone number of the lead</param>
        private Lead(
            Guid id,
            string? firstName,
            string lastName,
            string email,
            string? phoneNumber,
            Guid leadOwnerId) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            LeadOwnerId = leadOwnerId;
        }

        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public Guid LeadOwnerId { get; private set; }
        public LeadStatus Status { get; private set; }
    }
}
