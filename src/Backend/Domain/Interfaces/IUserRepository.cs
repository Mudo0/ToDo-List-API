using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Agrega un nuevo usuario a la base de datos.
        /// </summary>
        Task CreateAsync(User user);

        /// <summary>
        /// Encuentra el usuario por su id
        /// </summary>
        /// <param name="id"> Id del usuario</param>
        /// <returns><see cref="User"/> </returns>
        Task<User?> GetByIdAsync(Guid id);
    }
}