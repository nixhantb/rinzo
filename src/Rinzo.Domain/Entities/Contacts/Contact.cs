
using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;

namespace Rinzo.Domain.Entities.Contacts
    // If leads gets converted to deal, we automatically get lead as Contact 
{
    public class Contact : Entity
    {
        /// <summary>
        /// Private constructor used for controlled instantiation via factory methods or persistence.
        /// </summary>
        /// <param name="id">Unique identifier of the contact</param>
        ///  <param name="person">Person of the contact</param>
        /// <param name="genderType">Gender of the contact</param>
        /// <param name="mailingAddress">Mailing address (value object)</param>
        private Contact(
            Guid id,
            Person person,
            string jobTitle,
            Organization organization,
            Gender genderType, 
           
            Address mailingAddress) : base(id)
        {
            PersonId = person.Id;
           
            JobTitle = jobTitle;
            OrganizationId = organization.Id;
            GenderType = genderType;
            GenderType = genderType;
            MailingAddress = mailingAddress;
        }
       
        public string JobTitle { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Gender GenderType { get; private set; }
        public Address MailingAddress { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
