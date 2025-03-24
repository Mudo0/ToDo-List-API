using SharedKernel;

namespace Domain.Events
{
    public sealed record UserRegisteredEvent(Guid userId) : IDomainEvent
    {
    }
}