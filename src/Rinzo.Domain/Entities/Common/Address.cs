
namespace Rinzo.Domain.Entities.Common
{
    /// <summary>
    /// Address doesn't need its own identity (i.e., it's not an entity),
    /// we can treat it as a Value Object.
    /// </summary>
    /// <param name="Street"></param>
    /// <param name="City"></param>
    /// <param name="State"></param>
    /// <param name="PostalCode"></param>
    /// <param name="Country"></param>
    public record Address(
        string Street,
        string City,
        string State,
        string PostalCode,
        string Country);
}
