using MediatR;
using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Repositories;
using Rinzo.Domain.Shared;

namespace Rinzo.Application.Leads.Commands
{
    internal sealed class ConvertToDealCommandHandler : IRequestHandler<ConvertToDealCommand, Result<Guid>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConvertToDealCommandHandler(ILeadRepository leadRepository, IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _leadRepository = leadRepository;
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(ConvertToDealCommand request, CancellationToken cancellationToken)
        {
            var lead  = await _leadRepository.GetByIdAsync(request.LeadId, cancellationToken);
            if (lead is null)
            {
                return Result.Failure<Guid>(
                    new Error("Lead.NotFound", $"Lead with ID {request.LeadId} not found"));
            }

            var mailingAddress = new Address(
               request.MailingAddress.Street,
               request.MailingAddress.City,
               request.MailingAddress.State,
               request.MailingAddress.PostalCode,
               request.MailingAddress.Country);

            var contactResult =  lead.ConvertToDeal(request.JobTitle, request.Gender, mailingAddress);
            if (contactResult.IsFailure)
            {
                return Result.Failure<Guid>(contactResult.Error);
            }

            _contactRepository.AddContact(contactResult.value);
            _leadRepository.UpdateLead(lead);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

         
            return Result.Success(contactResult.value.Id);
        }
    }
}
