using Microsoft.Identity.Web.Resource;
using Oink.Core.Domain;
using Oink.FinancialAccountMgmt.Domain;
using Oink.FinancialAccountMgmt.Domain.Aggregates.FinancialAccount;

namespace Oink.FinancialAccountMgmt.Accounts.Api.HttpSurface;

public class AccountDataHttpSurface
{
    [OpenApiOperation(operationId: nameof(GetFinancialAccountByAccountId), tags: new[] { "financial-account" })]
    //[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Financial Account not found", Description = "Financial Account not found")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account found")]
    [FunctionName(nameof(GetFinancialAccountByAccountId))]
    public async Task<IActionResult> GetFinancialAccountByAccountId(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "accounts/{accountId}")] HttpRequest req,
        [CosmosDB(
                databaseName: "%FinancialAccount:Database%",
                containerName: "%FinancialAccount:EventsContainer%",
                Connection = "Cosmos",
                PartitionKey = "FinancialAccount/{accountId}"
        )] IEnumerable<StoredDomainEvent> accountEvents,
        string accountId,
        ILogger log)
    {
        var (isAuthenticated, authenticationResponse) =
           await req.HttpContext.AuthenticateAzureFunctionAsync();
        if (!isAuthenticated)
            return authenticationResponse ?? new UnauthorizedResult();
        req.HttpContext.VerifyUserHasAnyAcceptedScope("FinancialAccounts.Read");

        if (accountEvents?.Any() != true)
        {
            log.LogWarning($"Could not find Financial Account with ID {accountId}.");
            return new NotFoundResult();
        }
        var domainEvents = accountEvents.Select(evt => evt.AsDomainEventData()).ToList();

        if (domainEvents?.Any() != true) throw new InvalidOperationException($"Could not parse events for Financial Account with ID {accountId}.");

        var account = new Account(domainEvents);
        return new OkObjectResult(account);
    }

    [OpenApiOperation(operationId: nameof(GetFinancialAccountBalancesByAccountId), tags: new[] { "financial-account" })]
    //[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Financial Account not found", Description = "Financial Account not found")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account found")]
    [FunctionName(nameof(GetFinancialAccountBalancesByAccountId))]
    public async Task<IActionResult> GetFinancialAccountBalancesByAccountId(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "accounts/{accountId}/balances")] HttpRequest req,
    [CosmosDB(
                databaseName: "%FinancialAccount:Database%",
                containerName: "%FinancialAccount:EventsContainer%",
                Connection = "Cosmos",
                PartitionKey = "FinancialAccount/{accountId}"
        )] IEnumerable<StoredDomainEvent> accountEvents,
    string accountId,
    ILogger log)
    {
        var (isAuthenticated, authenticationResponse) =
        await req.HttpContext.AuthenticateAzureFunctionAsync();
        if (!isAuthenticated)
            return authenticationResponse ?? new UnauthorizedResult();
        req.HttpContext.VerifyUserHasAnyAcceptedScope("FinancialAccounts.Read");

        if (accountEvents?.Any() != true)
        {
            log.LogWarning($"Could not find account with ID {accountId}.");
            return new NotFoundResult();
        }
        var domainEvents = accountEvents.Select(evt => evt.AsDomainEventData()).ToList();

        if (domainEvents?.Any() != true) throw new InvalidOperationException($"Could not parse events for Financial Account with ID {accountId}.");

        var account = new Account(domainEvents);
        return new OkObjectResult(account);
    }

    [OpenApiOperation(operationId: nameof(GetAccountPaymentsByAccountId), tags: new[] { "financial-account" })]
    //[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Financial Account not found", Description = "Financial Account not found")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account found")]
    [FunctionName(nameof(GetAccountPaymentsByAccountId))]
    public async Task<IActionResult> GetAccountPaymentsByAccountId(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "accounts/{accountId}/payments")] HttpRequest req,
    [CosmosDB(
                databaseName: "%FinancialAccount:Database%",
                containerName: "%FinancialAccount:EventsContainer%",
                Connection = "Cosmos",
                PartitionKey = "FinancialAccount/{accountId}"
        )] IEnumerable<StoredDomainEvent> accountEvents,
    string accountId,
    ILogger log)
    {
        var (isAuthenticated, authenticationResponse) =
           await req.HttpContext.AuthenticateAzureFunctionAsync();
        if (!isAuthenticated)
            return authenticationResponse ?? new UnauthorizedResult();
        req.HttpContext.VerifyUserHasAnyAcceptedScope("FinancialAccounts.Read");

        if (accountEvents?.Any() != true)
        {
            log.LogWarning($"Could not find Financial Account with ID {accountId}.");
            return new NotFoundResult();
        }
        var domainEvents = accountEvents.Select(evt => evt.AsDomainEventData()).ToList();

        if (domainEvents?.Any() != true) throw new InvalidOperationException($"Could not parse events for Financial Account with ID {accountId}.");

        var account = new Account(domainEvents);
        return new OkObjectResult(account);
    }
}
