
using MediatR;
using Rinzo.Domain.Entities.Lead;
using Rinzo.Domain.Repositories;
using Rinzo.Domain.Shared;
namespace Rinzo.Application.Leads.Commands
{
    internal sealed class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Result<Guid>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeadCommandHandler(
            IContactRepository contactRepository,
            ILeadRepository leadRepository,
            IPersonRepository personRepository,
            IOrganizationRepository organizationRepository,
            IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _personRepository = personRepository;
            _organizationRepository = organizationRepository;
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.PersonId, cancellationToken);
            if (person == null)
            {
                return Result.Failure<Guid>(new Error("Person.NotFound", $"Person with ID {request.PersonId} not found."));
            }

            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId, cancellationToken);
            if (organization == null)
            {
                return Result.Failure<Guid>(new Error("Organization.NotFound", $"Organization with ID {request.OrganizationId} not found."));
            }

            var leadOwner = await _contactRepository.GetByIdAsync(request.LeadOwnerId, cancellationToken);
            if (leadOwner == null)
            {
                return Result.Failure<Guid>(new Error("LeadOwner.NotFound", $"Lead owner with ID {request.LeadOwnerId} not found."));
            }

            var lead = Lead.Create(person, organization, leadOwner, request.InitialStatus);
            _leadRepository.AddLead(lead);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(lead.Id);
        }
    }

}
