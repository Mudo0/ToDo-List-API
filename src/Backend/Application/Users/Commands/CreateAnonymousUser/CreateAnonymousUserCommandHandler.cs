using Application.Common.Abstractions.CQRS;
using Application.Common.Abstractions.Data;
using Application.Common.DTOs;
using Domain.Entities;
using Domain.Errors;
using Domain.Interfaces;
using ErrorOr;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.CreateAnonymousUser
{
    /// <summary>
    /// Manejador para el comando CreateAnonymousUserCommand.
    /// </summary>
    public sealed class CreateAnonymousUserCommandHandler
    (
    IUserRepository userRepository,
    ILogger<CreateAnonymousUserCommandHandler> logger,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateAnonymousUserCommand, UserDto>
    {
        public async Task<ErrorOr<UserDto>> HandleAsync(CreateAnonymousUserCommand command,
            CancellationToken cancellationToken)
        {
            //domain validation
            var createUserResult = User.Create();
            if (createUserResult.IsError)
            {
                logger.LogWarning("Error al crear usuario: {Errors}", createUserResult.Errors);
                return createUserResult.Errors;
            }
            var user = createUserResult.Value;

            //persistence
            try
            {
                await userRepository.AddAsync(user, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Usuario anónimo creado con éxito. ID:{UserId} ", user.Id);
            }
            //exceptions
            catch (Exception ex)
            {
                logger.LogError(ex,
                    "Error crítico al guardar el usuario en la base de datos.");
                return DomainErrors.User.SaveFailure();
            }

            //response
            var userDto = new UserDto(user.Id);
            return userDto;
        }
    }
}