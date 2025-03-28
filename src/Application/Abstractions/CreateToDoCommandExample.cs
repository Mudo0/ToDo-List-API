using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Application.Abstractions
{
    public class CreateToDoCommandExample
    {
        public Result<string> CreateToDo(string mail)
        {
            Result.Create(mail)
                .Ensure(
                    e => !string.IsNullOrEmpty(e),
                    Error.Failure("Email.Null", "The email can not be an empty string")
                    );

            return Result.Success(mail);
        }
    }
}