namespace Domain.Entities
{
    /// <summary>
    /// Entidad del dominio que representa a un usuario.
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }

        public virtual ICollection<TodoItem>? TodoItems { get; set; } = new List<TodoItem>();
    }
}