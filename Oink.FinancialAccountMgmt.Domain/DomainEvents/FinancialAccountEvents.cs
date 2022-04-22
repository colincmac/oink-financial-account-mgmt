using Oink.Core.Domain;
using Oink.Core.Domain.Contracts;
using Oink.FinancialAccountMgmt.Domain.Seedwork;

namespace Oink.FinancialAccountMgmt.Domain.DomainEvents;

// TODO: make it a saga, Initiated, Pending, Created, Disabled
[VersionedEvent("Oink.FinancialAccount", "CreationRequested")]
public sealed record FinancialAccountCreationRequested(
    Guid OinkFinancialAccountId,
    string AccountName,
    AccountClassification AccountClassification) : IDomainEvent;

[VersionedEvent("Oink.FinancialAccount", "StatusUpdated")]
public sealed record FinancialAccountStatusUpdated(Guid OinkFinancialAccountId, AccountStatusEnum UpdatedStatus) : IDomainEvent;

[VersionedEvent("Oink.FinancialAccount", "Disabled")]
public sealed record FinancialAccountDisabled(Guid OinkFinancialAccountId) : IDomainEvent;