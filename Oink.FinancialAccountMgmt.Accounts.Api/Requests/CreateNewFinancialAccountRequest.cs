namespace Oink.FinancialAccountMgmt.Accounts.Api.Requests;
public class CreateNewFinancialAccountRequest
{
    public Guid AccountId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public string AccountClassIdentifier { get; set; } = string.Empty;
}
