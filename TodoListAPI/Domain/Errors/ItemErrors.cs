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
            new("Item.NotFound", $"The item with the {itemId} was not found", ErrorType.NotFound);
    }
}