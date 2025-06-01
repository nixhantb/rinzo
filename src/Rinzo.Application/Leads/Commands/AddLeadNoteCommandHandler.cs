

using MediatR;
using Rinzo.Domain.Repositories;

namespace Rinzo.Application.Leads.Commands
{
    internal sealed class AddLeadNoteCommandHandler: IRequestHandler<AddLeadCommand, bool>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddLeadNoteCommandHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork)
        {
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.LeadId, cancellationToken);
            if (lead is null)
            {
                return false; 
            }
            lead.AddNote(request.CreatedBy, request.Content);
            _leadRepository.UpdateLead(lead);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true; 
        }

    }
}
