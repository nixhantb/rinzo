
using MediatR;
using Rinzo.Domain.Entities.Contacts;
using Rinzo.Domain.Repositories;
using Rinzo.Domain.Shared;

namespace Rinzo.Application.Contacts.Command
{
    internal sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<Guid>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactCommandHandler(IPersonRepository personRepository, IOrganizationRepository organizationRepository, IContactRepository contactRepository,  IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _organizationRepository = organizationRepository;
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.PersonId, cancellationToken);

            if (person == null)
            {
                return Result.Failure<Guid>(new Error("Person.NotFound", $"Person with ID {request.PersonId} not found."));
            }

            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId, cancellationToken);
            
            if(organization == null)
            {
                return Result.Failure<Guid>(new Error("Organization.NotFound", $"Organization with ID {request.OrganizationId} not found"));

            }

            var contact = Contact.Create(person, request.jobTitle, organization, request.genderType,request.mailingAddress);

            _contactRepository.AddContact(contact);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(contact.Id);
        }
    }
}
