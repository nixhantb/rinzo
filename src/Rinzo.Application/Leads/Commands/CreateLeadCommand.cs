
using MediatR;
using Rinzo.Domain.Enums;
namespace Rinzo.Application.Leads.Commands
{
    public sealed record CreateLeadCommand
    (
        Guid PersonId,
        Guid OrganizationId,
        Guid LeadOwnerId,
        LeadStatus InitialStatus= LeadStatus.New
    ):  IRequest<Guid>;
}
