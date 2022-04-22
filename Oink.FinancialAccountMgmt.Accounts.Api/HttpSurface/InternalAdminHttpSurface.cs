namespace Oink.FinancialAccountMgmt.Accounts.Api.HttpSurface;
public class InternalAdminHttpSurface
{
    //[OpenApiOperation(operationId: nameof(CreateUserProfile), tags: new[] { "user" }, Summary = "Create a user profile", Description = "Creates a new user profile for the Oink system.", Visibility = OpenApiVisibilityType.Important)]
    ////[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    //[OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CreateNewFinancialAccountRequest), Required = true, Description = "Created user object")]
    //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "User already exists", Description = "User already exists")]
    //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(FinancialAccount), Description = "User created")]
    //[FunctionName(nameof(CreateUserProfile))]
    //public async Task<IActionResult> CreateUserProfile(
    //[HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/{userId}/profile")] CreateNewFinancialAccountRequest req,
    //[CosmosDB(
    //        databaseName: "%UserProfile:Database%",
    //        containerName: "%UserProfile:EventsContainer%",
    //        Connection = "Cosmos",
    //        PartitionKey = "OinkUser/{userId}"
    //)] IEnumerable<StoredDomainEvent> profileEvents,
    //[CosmosDB(
    //        databaseName: "%UserProfile:Database%",
    //        containerName: "%UserProfile:EventsContainer%",
    //        Connection = "Cosmos"
    //)] IAsyncCollector<StoredDomainEvent> wrappedEventsOut,
    //ILogger log)
    //{
    //    if (profileEvents?.Count() > 0)
    //    {
    //        log.LogWarning($"User with ID {req.IdentityProviderId} already exists.");
    //        return new BadRequestResult();
    //    }

    //    var userProfile = OinkUserProfile.Create(req.IdentityProviderId, req.UserDisplayName, req.AvatarUri);

    //    foreach (var evt in userProfile.DomainEvents)
    //    {
    //        var wrappedEvent = evt.WrapUserEvent(nameof(CreateUserProfile), userProfile.Id.ToString());
    //        await wrappedEventsOut.AddAsync(wrappedEvent);
    //    }

    //    return new OkObjectResult(userProfile);
    //}

    //[OpenApiOperation(operationId: nameof(DeleteUserProfile), tags: new[] { "user" }, Summary = "Delete a user profile", Description = "Soft deletes a user profile for the Oink system.", Visibility = OpenApiVisibilityType.Important)]
    ////[OpenApiSecurity("function_key", SecuritySchemeType.OAuth2, Name = "code", In = OpenApiSecurityLocationType.Header)]
    //[OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "User not found", Description = "User not found")]
    //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.OK, Description = "User profile deleted")]
    //[FunctionName(nameof(DeleteUserProfile))]
    //public async Task<IActionResult> DeleteUserProfile(
    //[HttpTrigger(AuthorizationLevel.Function, "delete", Route = "users/{userId}/profile")] HttpRequest req,
    //[CosmosDB(
    //            databaseName: "%UserProfile:Database%",
    //            containerName: "%UserProfile:EventsContainer%",
    //            Connection = "Cosmos",
    //            PartitionKey = "OinkUser/{userId}"
    //    )] IEnumerable<StoredDomainEvent> profileEvents,
    //[CosmosDB(
    //            databaseName: "%UserProfile:Database%",
    //            containerName: "%UserProfile:EventsContainer%",
    //            Connection = "Cosmos"
    //    )] IAsyncCollector<StoredDomainEvent> wrappedEventsOut,
    //Guid userId,
    //ILogger log)
    //{
    //    if (profileEvents?.Any() != true)
    //    {
    //        log.LogWarning($"Could not find user with ID {userId}.");
    //        return new NotFoundResult();
    //    }

    //    var domainEvents = profileEvents.Select(evt => evt.AsDomainEventData()).ToList();

    //    if (domainEvents?.Any() != true) throw new InvalidOperationException($"Could not parse events for user with ID {userId}.");

    //    var user = new OinkUserProfile(domainEvents);

    //    user.Disable();

    //    foreach (var evt in user.DomainEvents)
    //    {
    //        var wrappedEvent = evt.WrapUserEvent(nameof(DeleteUserProfile), user.Id.ToString());
    //        await wrappedEventsOut.AddAsync(wrappedEvent);
    //    }

    //    return new OkResult();
    //}

}
