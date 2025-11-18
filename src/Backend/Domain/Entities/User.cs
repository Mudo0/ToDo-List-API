using ErrorOr;

namespace Domain.Entities
{
    /// <summary>
    /// Entidad del dominio que representa a un usuario.
    /// </summary>
    public class User
    {
        public Guid Id { get; private set; }

        public virtual ICollection<TodoItem>? TodoItems { get; private set; } = [];

        private User()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Método fabrica para crear una nueva instancia de User.
        /// </summary>
        /// <returns>Un nuevo usuario anónimo</returns>
        public static ErrorOr<User> Create()
        {
            var user = new User();
            return user;
        }
    }
}