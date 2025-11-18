using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Domain.Errors
{
    public static partial class DomainErrors
    {
        /// <summary>
        /// Clase estática para definir y acceder a los errores relacionados con la entidad User.
        /// </summary>
        public static class User
        {
            public static Error UserNotFound() =>
                Error.NotFound(
                    code: "User.NotFound",
                    description: "The user was not found.");
        }
    }
}