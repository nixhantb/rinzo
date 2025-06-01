
using MediatR;
using Rinzo.Domain.Repositories;

namespace Rinzo.Application.Leads.Commands
{
    internal sealed class AddLeadTaskCommandHandler : IRequestHandler<AddLeadTaskCommand, bool>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddLeadTaskCommandHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork)
        {
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(AddLeadTaskCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.LeadId, cancellationToken);
            if (lead is null)
            {
                return false; 
            }
            lead.AddTaskActivity(request.CreatedBy, request.Title, request.Description);
            _leadRepository.UpdateLead(lead);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true; 
        }
    }
}
