

using MediatR;
using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Shared;

namespace Rinzo.Application.Leads.Commands
{
    public sealed record ConvertToDealCommand
    (
        Guid LeadId,
        string JobTitle,
        Address MailingAddress

    ) : IRequest<Result<Guid>>;
}
