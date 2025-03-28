using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors
{
    public static class ItemErrors
    {
        public static Error NotFound(Guid itemId) =>
            new("Item.NotFound", $"The item: ID({itemId}) was not found", ErrorType.NotFound);

        public static Error NotInserted() =>
            new("Item.Not.Inserted", "The item could not be inserted", ErrorType.Conflict);
    }
}