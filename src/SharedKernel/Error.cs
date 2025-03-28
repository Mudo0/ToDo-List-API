using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public record Error
    {
        //value for an empty error
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

        //error for a null
        public static readonly Error NullValue = new(
            "General.Null",
            "Null value was provided",
            ErrorType.Failure);

        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; }

        //converts an error to a result
        //we can return an error in a method that returns a result
        public static implicit operator Result(Error error) => Result.Failure(error);

        //ctor
        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        //factory methods for each category error
        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Problem(string code, string description) =>
            new(code, description, ErrorType.Problem);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);
    }
}