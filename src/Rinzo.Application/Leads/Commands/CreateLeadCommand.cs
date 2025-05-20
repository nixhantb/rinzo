
using MediatR;
using Rinzo.Domain.Enums;
using Rinzo.Domain.Shared;
namespace Rinzo.Application.Leads.Commands
{
    public sealed record CreateLeadCommand(
    Guid PersonId,
    Guid OrganizationId,
    Guid LeadOwnerId,
    LeadStatus InitialStatus = LeadStatus.New
) : IRequest<Result<Guid>>;


}
