using Application.Common.Abstractions.CQRS;
using Application.Common.DTOs;

namespace Application.Users.Commands.CreateAnonymousUser
{
    /// <summary>
    /// Comando para crear un usuario anónimo.
    /// No tiene parámetros.
    /// Devuelve un UserDto que representa al usuario anónimo creado.
    /// </summary>
    public sealed record CreateAnonymousUserCommand() : ICommand<UserDto>;
    //record se utiliza para definir una clase que solo transporta datos
    //sealed se utiliza para evitar que la clase sea heredada
}