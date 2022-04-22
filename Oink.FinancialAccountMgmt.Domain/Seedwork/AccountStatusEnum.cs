using System.Text.Json.Serialization;

namespace Oink.FinancialAccountMgmt.Domain.Seedwork;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountStatusEnum
{
    Unknown = 0,
    Initiated,
    Pending,
    Disabled,
    Deleted
}
