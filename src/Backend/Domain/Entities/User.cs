

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public virtual ICollection<TodoItem>? TodoItems { get; set; } = new List<TodoItem>();
    }
}