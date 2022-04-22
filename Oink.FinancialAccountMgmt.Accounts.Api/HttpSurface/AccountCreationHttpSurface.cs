using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Identity.Web.Resource;
using Oink.Core.Domain;
using Oink.FinancialAccountMgmt.Accounts.Api.Requests;
using Oink.FinancialAccountMgmt.Domain;
using Oink.FinancialAccountMgmt.Domain.Aggregates.FinancialAccount;
using Oink.FinancialAccountMgmt.Domain.DomainEvents;
using Oink.FinancialAccountMgmt.Domain.Seedwork;

namespace Oink.FinancialAccountMgmt.Accounts.Api.HttpSurface;
public class AccountCreationHttpSurface
{
    private readonly TelemetryClient _telemetryClient;

    public AccountCreationHttpSurface(TelemetryConfiguration telemetryConfiguration)
    {
        _telemetryClient = new TelemetryClient(telemetryConfiguration);
    }

    [OpenApiOperation(operationId: nameof(RequestFinancialAccountCreation), tags: new[] { "admin" })]
    [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CreateNewFinancialAccountRequest), Required = true, Description = "Account information needed to create an account reference in the Oink system.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Conflict, Summary = "Financial Account creation account exists", Description = "Financial Account creation request already exists")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account creation requested")]
    [FunctionName(nameof(RequestFinancialAccountCreation))]
    public async Task<IActionResult> RequestFinancialAccountCreation(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "accounts")] CreateNewFinancialAccountRequest reqBody,
        [CosmosDB(
                databaseName: "%FinancialAccount:Database%",
                containerName: "%FinancialAccount:EventsContainer%",
                Connection = "Cosmos",
                PartitionKey = "FinancialAccount/{accountId}"
        )] IEnumerable<StoredDomainEvent> accountEvents,
        [CosmosDB(
                databaseName: "%FinancialAccount:Database%",
                containerName: "%FinancialAccount:EventsContainer%",
                Connection = "Cosmos"
        )] IAsyncCollector<StoredDomainEvent> wrappedEventsOut,
        HttpRequest req,
        Guid accountId,
        ILogger log)
    {
        var (isAuthenticated, authenticationResponse) =
        await req.HttpContext.AuthenticateAzureFunctionAsync();
        if (!isAuthenticated)
            return authenticationResponse ?? new UnauthorizedResult();
        req.HttpContext.VerifyUserHasAnyAcceptedScope("FinancialAccounts.Create");

        if (accountEvents?.Count() > 0)
        {
            log.LogWarning($"Financial Account with ID {accountId} already exists.");
            return new BadRequestResult();
        }
        AccountClassification.TryFromValue(reqBody.AccountClassIdentifier, out var accountClassification);
        var account = Account.RequestCreation(accountId, reqBody.AccountName, accountClassification ?? AccountClassification.OinkUnknown);

        foreach (var evt in account.DomainEvents)
        {
            var wrappedEvent = evt.WrapUserEvent(nameof(FinancialAccountCreationRequested), account.Id.ToString());
            await wrappedEventsOut.AddAsync(wrappedEvent);
        }
        return new OkObjectResult(account);
    }

}
