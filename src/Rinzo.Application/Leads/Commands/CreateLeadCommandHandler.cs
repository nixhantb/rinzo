
using MediatR;
using Rinzo.Domain.Repositories;

namespace Rinzo.Application.Leads.Commands
{
    internal sealed class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Guid>
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeadCommandHandler(
            IContactRepository contactRepository,
            ILeadRepository leadRepository,
            IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<Guid> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    
}
