

using MediatR;

namespace Rinzo.Application.Leads.Commands
{
    public sealed record AddLeadCommand(
        Guid LeadId,
        Guid CreatedBy,
        string Content
        ): IRequest<bool>;
}
