using MediatR;

namespace DomainDrivenFramework.DomainEvents
{
    public abstract record DomainEvent : INotification;
}
