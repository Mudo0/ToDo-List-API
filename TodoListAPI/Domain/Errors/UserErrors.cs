using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error error = new("User.NotFound", "User was not found", ErrorType.NotFound);
    }
}