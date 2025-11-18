using Domain.Errors;
using ErrorOr;
using Error = ErrorOr.Error;

namespace Domain.Entities
{
    /// <summary>
    /// Entidad del dominio que representa una tarea (To-Do) en el sistema.
    /// Contiene toda la lógica de negocio para validar y modificar su propio estado.
    /// </summary>
    public class TodoItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public TodoStatus Status { get; private set; }
        public DateTime? LimitDate { get; private set; }

        public bool IsCompleted => Status == TodoStatus.Completed;

        //User Relationship
        public Guid UserId { get; set; }

        /// <summary>
        /// Propiedad de navegación para el usuario.
        /// Puede ser nula si no se carga explícitamente (Lazy/Eager Loading).
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Constructor privado requerido por Entity Framework Core para la hidratación.
        /// Asigna 'null!' a las propiedades no anulables para cumplir con C#.
        /// </summary>
        private TodoItem()
        {
            //ef will complete the title property using reflection
            Title = null!;
        }

        /// <summary>
        /// Constructor privado que es llamado por el método fábrica 'Create'.
        /// </summary>
        private TodoItem(string title, Guid userId, DateTime? limitDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            LimitDate = limitDate;
            UserId = userId;
            Status = TodoStatus.Pending;
        }

        //static factory method

        /// <summary>
        /// Crea una nueva instancia de <see cref="TodoItem"/> validando las reglas de negocio.
        /// </summary>
        /// <param name="title">El título de la tarea. No puede estar vacío ni exceder los 100 caracteres.</param>
        /// <param name="userId">El ID del usuario al que pertenece la tarea (no puede ser Guid.Empty).</param>
        /// <param name="limitDate">La fecha límite opcional (no puede estar en el pasado).</param>
        /// <returns>
        /// Un <see cref="ErrorOr{T}"/> que contiene la nueva entidad <see cref="TodoItem"/> si es exitoso,
        /// o una lista de <see cref="Error"/> de validación si falla.
        /// </returns>

        public static ErrorOr<TodoItem> Create(string title, Guid userId, DateTime? limitDate = null)
        {
            //possible errors
            List<Error> errors = [];

            //Validations
            errors.AddRange(ValidateTitle(title));
            errors.AddRange(ValidateUser(userId));
            errors.AddRange(ValidateDueDate(limitDate));

            if (errors.Any())
            {
                return errors;
            }

            var todoItem = new TodoItem(title, userId, limitDate);
            return todoItem;
        }

        // --- MÉTODOS DE VALIDACIÓN (Privados) ---

        /// <summary>
        /// Valida las reglas de negocio para el título.
        /// </summary>
        private static List<Error> ValidateTitle(string title)
        {
            List<Error> errors = [];
            if (string.IsNullOrWhiteSpace(title))
            {
                errors.Add(DomainErrors.TodoItem.TitleEmptyOrWhiteSpace());
            }

            if (title.Length > 100)
            {
                errors.Add(DomainErrors.TodoItem.TitleTooLong());
            }

            return errors;
        }

        /// <summary>
        /// Valida las reglas de negocio para el ID del usuario.
        /// </summary>
        private static List<Error> ValidateUser(Guid userId)
        {
            List<Error> errors = [];
            if (userId == Guid.Empty)
            {
                errors.Add(DomainErrors.TodoItem.InvalidUserId());
            }
            return errors;
        }

        /// <summary>
        /// Valida las reglas de negocio para la fecha límite.
        /// </summary>
        private static List<Error> ValidateDueDate(DateTime? limitDate)
        {
            List<Error> errors = [];
            if (limitDate.HasValue && limitDate.Value < DateTime.UtcNow)
            {
                errors.Add(DomainErrors.TodoItem.InvalidDate());
            }

            return errors;
        }

        // --- COMPORTAMIENTOS (Métodos de Negocio) ---

        /// <summary>
        /// Marca la tarea como completada, validando las reglas de estado.
        /// </summary>
        /// <returns>
        /// Un <see cref="ErrorOr{T}"/> de tipo <see cref="Success"/> o un <see cref="Error"/>
        /// si la transición de estado no es válida (ej. si está cancelada).
        /// </returns>
        public ErrorOr<Success> MarkAsCompleted()
        {
            if (Status == TodoStatus.Cancelled)
            {
                return DomainErrors.TodoItem.CompleteACancelledTask();
            }

            Status = TodoStatus.Completed;
            return Result.Success;
        }

        /// <summary>
        /// Pone la tarea en estado 'InProgress', validando las reglas de estado.
        /// </summary>
        /// <returns>
        /// Un <see cref="ErrorOr{T}"/> de tipo <see cref="Success"/> o un <see cref="Error"/>
        /// si la transición de estado no es válida.
        /// </returns>
        public ErrorOr<Success> StartProgress()
        {
            if (Status == TodoStatus.Cancelled)
            {
                return DomainErrors.TodoItem.StartProgressACancelledTask();
            }
            Status = TodoStatus.InProgress;
            return Result.Success;
        }

        /// <summary>
        /// Cancela la tarea, validando las reglas de estado.
        /// </summary>
        /// <returns>
        /// Un <see cref="ErrorOr{T}"/> de tipo <see cref="Success"/> o un <see cref="Error"/>
        /// si la transición de estado no es válida (ej. si ya está completada).
        /// </returns>
        public ErrorOr<Success> Cancel()
        {
            if (Status == TodoStatus.Completed)
            {
                return DomainErrors.TodoItem.CancelACompleteTask();
            }
            Status = TodoStatus.Cancelled;
            return Result.Success;
        }

        /// <summary>
        /// Actualiza el título de la tarea después de validarlo.
        /// </summary>
        /// <param name="newTitle">El nuevo título para la tarea.</param>
        /// <returns>
        /// Un <see cref="ErrorOr{T}"/> de tipo <see cref="Success"/> o una lista de
        /// <see cref="Error"/> de validación si el nuevo título es inválido.
        /// </returns>
        public ErrorOr<Success> UpdateTitle(string newTitle)
        {
            // Reutilizamos la misma lógica de validación
            var errors = ValidateTitle(newTitle);
            if (errors.Any())
            {
                return errors;
            }

            Title = newTitle;
            return Result.Success;
        }
    }
}