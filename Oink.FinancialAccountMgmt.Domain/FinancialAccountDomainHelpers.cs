using Oink.Core.Domain;
using Oink.Core.Domain.Contracts;
using Oink.Core.Domain.Extensions;
using System.Reflection;

namespace Oink.FinancialAccountMgmt.Domain;
public static class FinancialAccountDomainHelpers
{
    public const string FinancialAccountSubjectPrefix = "FinancialAccount";
    public const string EventIdentifierBase = "Oink.FinancialAccount";

    public static StoredDomainEvent WrapUserEvent<TEventType>(this TEventType eventItem, string requestSource, string eventSubject, string? eventName = default) where TEventType : class, IDomainEvent
    {
        var data = eventItem.GetEventMetadata();
        var subject = $"{FinancialAccountSubjectPrefix}/{eventSubject}";
        var type = data?.FullVersionedName ?? $"{EventIdentifierBase}.{eventName ?? typeof(TEventType).Name}";

        return new StoredDomainEvent(subject, type, requestSource, eventItem);
    }

    public static IDomainEvent AsDomainEventData(this StoredDomainEvent eventItem)
    {
        var eventDataType = EventRegistry.GetEventDataType(eventItem.Type);

        var generic = typeof(FinancialAccountDomainHelpers)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .First(m => m.IsGenericMethod && m.Name == "AsDomainEventData")
            .MakeGenericMethod(eventDataType);

        var deserializedEvent = generic.Invoke(null, new object[] { eventItem }) as IDomainEvent;
        if (deserializedEvent == null) throw new InvalidOperationException("Could not deserialize event from JSON.");

        return deserializedEvent;
    }

    public static TEvent AsDomainEventData<TEvent>(StoredDomainEvent eventItem) where TEvent : class, IDomainEvent
    {
        return eventItem.Data.ToObjectFromJson<TEvent>();
    }
}
