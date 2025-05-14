using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Entities.Contacts;
using Rinzo.Domain.Enums;
using Rinzo.Domain.Primitives;
using Rinzo.Domain.Shared;


namespace Rinzo.Domain.Entities.Lead
{
    public sealed class Lead : Entity
    {
        private readonly List<LeadActivity> _activities = new();
        public IReadOnlyCollection<LeadActivity> Activities => _activities.AsReadOnly();

        /// <summary>
        /// Private constructor used for controlled instantiation via factory methods or persistence.
        /// </summary>
        /// <param name="id">Unique identifier of the lead</param>
        /// <param name="personId">ID of the person</param>
        /// <param name="organizationId">ID of the organization</param>
        /// <param name="leadOwnerId">ID of the lead owner (contact)</param>
        /// <param name="status">Current status of the lead</param>
        private Lead(
            Guid id,
            Person person,
            Organization organization,
            Contact leadOwner,
            LeadStatus status) : base(id)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            LeadOwner = leadOwner ?? throw new ArgumentNullException(nameof(leadOwner));

            PersonId = person.Id;
            OrganizationId = organization.Id;
            LeadOwnerId = leadOwner.Id;
            Status = status;
            CreatedOn = DateTime.UtcNow;
        }
        public Person Person { get; private set; }
        public Organization Organization { get; private set; }
        public Contact LeadOwner { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Guid LeadOwnerId { get; private set; }

        public LeadStatus Status { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public void AddNote(Guid createdBy, string content)
        {
            var note = new NoteActivity(Guid.NewGuid(), Id, createdBy, content);
            _activities.Add(note);
        }

        public void AddTaskActivity(Guid createdBy, string? title, string? description)
        {
            var taskActivity = TaskActivity.CreateTaskActivity(
                leadId: Id,
                createdBy: createdBy,
                title: title,
                description: description,
                createdOn: DateTime.UtcNow
            );

            _activities.Add(taskActivity);
        }
        /// <summary>
        /// Converts the lead to a deal by creating a new contact.
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <param name="gender"></param>
        /// <param name="mailingAddress"></param>
        /// <returns>The newly created contact</returns>
        public Result<Contact> ConvertToDeal(string jobTitle, Gender gender, Address mailingAddress)
        {
            if (Status == LeadStatus.Converted)
            {
                return Result.Failure<Contact>(
                    new Error("Lead.AlreadyConverted", "Lead has already been converted to a deal.")
                );
            }

            var contact = new Contact(
                id: Guid.NewGuid(),
                person: Person,
                jobTitle: jobTitle,
                organization: Organization,
                genderType: gender,
                mailingAddress: mailingAddress
            );

            // Update state
            Status = LeadStatus.Converted;
            UpdatedOn = DateTime.UtcNow;

            var conversionActivity = new ConversionActivity(
                id: Guid.NewGuid(),
                leadId: Id,
                createdBy: LeadOwnerId,
                ContactId: contact.Id
            );
            // Add conversion activity to the lead
            _activities.Add(conversionActivity);

            return Result.Success(contact);
        }

        // Factory method for creating a new lead
        public static Lead Create(
            Person person,
            Organization organization,
            Contact leadOwner,
            LeadStatus initialStatus = LeadStatus.New)
        {
            return new Lead(
                id: Guid.NewGuid(),
                person: person,
                organization: organization,
                leadOwner: leadOwner,
                status: initialStatus
            );
        }
    }
}
