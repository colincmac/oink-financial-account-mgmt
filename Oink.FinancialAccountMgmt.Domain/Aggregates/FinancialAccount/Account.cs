using Oink.Core.Domain;
using Oink.Core.Domain.Contracts;
using Oink.Core.Domain.Exceptions;
using Oink.FinancialAccountMgmt.Domain.DomainEvents;
using Oink.FinancialAccountMgmt.Domain.Seedwork;

namespace Oink.FinancialAccountMgmt.Domain.Aggregates.FinancialAccount;
public sealed class Account : AggregateRoot
{
    public string AccountName { get; set; }
    public AccountClassification Classification { get; private set; } = AccountClassification.OinkUnknown;
    public AccountStatusEnum Status { get; private set; }
    public bool IsActive { get; private set; }

    public Account(IReadOnlyCollection<IDomainEvent> eventItems) : base(eventItems)
    {
    }

    private Account()
    {
    }

    #region Commands
    public static Account RequestCreation(Guid oinkFinancialAccountId, string accountName, AccountClassification classification)
    {
        var newProfile = new Account();

        newProfile.Apply(new FinancialAccountCreationRequested(oinkFinancialAccountId, accountName, classification));
        return newProfile;
    }

    public Account UpdateStatus(Guid oinkFinancialAccountId, AccountStatusEnum status)
    {
        if (!IsActive) throw new DomainOperationException($"Financial Account with ID {Id} has been deactivated.");

        Apply(new FinancialAccountStatusUpdated(oinkFinancialAccountId, status));
        return this;
    }

    public void Disable()
    {
        if (!IsActive) throw new DomainOperationException($"Financial Account with ID {Id} has been deactivated.");
        Apply(new FinancialAccountDisabled(Id));
    }


    #endregion

    #region Event Handlers
    public void On(FinancialAccountCreationRequested eventItem)
    {
        Id = eventItem.OinkFinancialAccountId;
        Classification = eventItem.AccountClassification;
        Status = AccountStatusEnum.Initiated;
        AccountName = eventItem.AccountName;
        IsActive = true;
    }

    public void On(FinancialAccountStatusUpdated eventItem)
    {
        Id = eventItem.OinkFinancialAccountId;
        Status = eventItem.UpdatedStatus;
    }

    public void On(FinancialAccountDisabled _)
    {
        IsActive = false;
        Status = AccountStatusEnum.Disabled;
    }

    #endregion
}
