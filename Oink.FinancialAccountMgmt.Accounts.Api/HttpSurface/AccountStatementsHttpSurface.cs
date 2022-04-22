namespace Oink.FinancialAccountMgmt.Accounts.Api.HttpSurface;

public class AccountStatementsHttpSurface
{
    //[OpenApiOperation(operationId: nameof(GetFinancialAccountById), tags: new[] { "financial-account" })]
    //[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    //[OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Financial Account not found", Description = "Financial Account not found")]
    //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account found")]
    //[FunctionName(nameof(GetFinancialAccountById))]
    //public async Task<IActionResult> GetFinancialAccountById(
    //    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "accounts/{accountId}")] HttpRequest req,
    //    [CosmosDB(
    //            databaseName: "%FinancialAccount:Database%",
    //            containerName: "%FinancialAccount:EventsContainer%",
    //            Connection = "Cosmos",
    //            PartitionKey = "FinancialAccount/{accountId}"
    //    )] IEnumerable<StoredDomainEvent> accountEvents,
    //    string userId,
    //    ILogger log)
    //{
    //    var (isAuthenticated, authenticationResponse) =
    //       await req.HttpContext.AuthenticateAzureFunctionAsync();
    //    if (!isAuthenticated)
    //        return authenticationResponse ?? new UnauthorizedResult();
    //    return new OkResult();
    //}

    //[OpenApiOperation(operationId: nameof(GetFinancialAccountBalances), tags: new[] { "financial-account" })]
    //[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    //[OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Financial Account not found", Description = "Financial Account not found")]
    //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Financial Account found")]
    //[FunctionName(nameof(GetFinancialAccountById))]
    //public async Task<IActionResult> GetFinancialAccountBalances(
    //[HttpTrigger(AuthorizationLevel.Function, "get", Route = "accounts/{accountId}/balances")] HttpRequest req,
    //[CosmosDB(
    //            databaseName: "%FinancialAccount:Database%",
    //            containerName: "%FinancialAccount:EventsContainer%",
    //            Connection = "Cosmos",
    //            PartitionKey = "FinancialAccount/{accountId}"
    //    )] IEnumerable<StoredDomainEvent> accountEvents,
    //string userId,
    //ILogger log)
    //{
    //    var (isAuthenticated, authenticationResponse) =
    //       await req.HttpContext.AuthenticateAzureFunctionAsync();
    //    if (!isAuthenticated)
    //        return authenticationResponse ?? new UnauthorizedResult();

    //    if (accountEvents?.Any() != true)
    //    {
    //        log.LogWarning($"Could not find user with ID {userId}.");
    //        return new NotFoundResult();
    //    }
    //    var domainEvents = accountEvents.Select(evt => evt.AsDomainEventData()).ToList();

    //    if (domainEvents?.Any() != true) throw new InvalidOperationException($"Could not parse events for user with ID {userId}.");

    //    var user = new Account(domainEvents);
    //    return new OkObjectResult(user);
    //}

}
