using SharedKernel;

namespace Domain.Errors
{
    public static class ItemErrors
    {
        public static Error NotFound(Guid itemId) =>
            new("Item.NotFound", $"The item: ID({itemId}) was not found", ErrorType.NotFound);

        public static Error NotInserted() =>
            new("Item.Not.Inserted", "The item could not be inserted", ErrorType.Conflict);

        public static Error NotDeleted() =>
            new("Item.Not.Deleted", "The item was not deleted", ErrorType.Failure);
    }
}