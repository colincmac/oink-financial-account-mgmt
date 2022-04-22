using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace Oink.FinancialAccountMgmt.Domain.Seedwork;
// https://github.com/ardalis/SmartEnum

[JsonConverter(typeof(SmartEnumValueConverter<AccountClassification, string>))]
public class AccountClassification : SmartEnum<AccountClassification, string>
{
    // This would be hydrated from a Data ETL
    private const string OinkDefaultAccountProductIdentifier = "00000000-0000-0000-0000-000000000000";
    private const string OinkPersonalAccountProductIdentifier = "00000000-0000-0000-0000-000000000001";
    private const string OinkBusinessAccountProductIdentifier = "00000000-0000-0000-0000-000000000002";
    private const string OinkEnterpriseAccountProductIdentifier = "00000000-0000-0000-0000-000000000003";

    // Accounting for failure.
    public static readonly AccountClassification OinkUnknown = new("Oink Unknown Account", OinkDefaultAccountProductIdentifier, FinancialAccountClassEnum.Unknown);

    // Default known account classifications (Name, Product Identifier, Account Type, and Product Owner)
    public static readonly AccountClassification OinkPersonal = new("Oink Personal Account", OinkPersonalAccountProductIdentifier, FinancialAccountClassEnum.Personal);
    public static readonly AccountClassification OinkBusiness = new("Oink Business Account", OinkBusinessAccountProductIdentifier, FinancialAccountClassEnum.Business);
    public static readonly AccountClassification OinkEnterprise = new("Oink Enterprise Account", OinkEnterpriseAccountProductIdentifier, FinancialAccountClassEnum.Enterprise);

    public Guid ProductOwnerIdentifier { get; set; }
    public FinancialAccountClassEnum AccountClass { get; set; }

    public AccountClassification(string name, string productIdentifier, FinancialAccountClassEnum accountClass, Guid productOwnerIdentifier = default) : base(name, productIdentifier)
    {
        AccountClass = accountClass;
        ProductOwnerIdentifier = productOwnerIdentifier;
    }
}
