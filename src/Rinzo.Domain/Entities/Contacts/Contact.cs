
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
        /// <param name="person">Person of the contact</param>
        /// <param name="jobTitle">Job title of the contact</param>
        /// <param name="organization">Organization associated with the contact</param>
        /// <param name="genderType">Gender of the contact</param>
        /// <param name="mailingAddress">Mailing address (value object)</param>
        internal Contact(
            Guid id,
            Person person,
            string jobTitle,
            Organization organization,
            Gender genderType, 
            Address mailingAddress) : base(id)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            PersonId = person.Id;
            JobTitle = jobTitle;

            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            OrganizationId = organization.Id;
            GenderType = genderType;
            GenderType = genderType;
            MailingAddress = mailingAddress;
            CreatedOn = DateTime.UtcNow;
        }
       

       
        public Person Person { get; private set; }
        public Guid PersonId { get; private set; }
        public string JobTitle { get; private set; }
        public Organization Organization { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Gender GenderType { get; private set; }
        public Address MailingAddress { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        

        // Factory Method for creating a new Contact

        public static Contact Create(
            Person person,
            string jobTitle,
            Organization organization,
            Gender genderType, 
            Address mailingAddress

            )
        {

            return new Contact(
                    
                    id: Guid.NewGuid(),
                    person: person,
                    jobTitle: jobTitle,
                    organization: organization,
                    genderType: genderType,
                    mailingAddress: mailingAddress
                );

        }
        

    }


}
