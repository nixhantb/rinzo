using MediatR;
namespace Rinzo.Application.Leads.Commands
{
   internal sealed record class AddLeadTaskCommand(
        Guid LeadId,
        Guid CreatedBy,
        string Title,
        string Description
    ) : IRequest<bool>;
}
