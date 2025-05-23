
using MediatR;
using Rinzo.Domain.Entities.Common;
using Rinzo.Domain.Enums;
using Rinzo.Domain.Shared;

namespace Rinzo.Application.Contacts.Command
{
    public sealed record CreateContactCommand(

        Guid PersonId,
        string jobTitle,
        Guid OrganizationId,
        Address mailingAddress,
        Gender genderType
        ): IRequest<Result<Guid>>;
}
