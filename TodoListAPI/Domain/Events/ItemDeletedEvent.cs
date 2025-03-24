using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public sealed record ItemDeletedEvent(Guid itemId) : IDomainEvent
    {
    }
}