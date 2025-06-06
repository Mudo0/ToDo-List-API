﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public static class ResultExtensions

    {
        public static Result<T> Ensure<T>(
            this Result<T> result,
            Func<T, bool> predicate,
            Error error)
        {
            return predicate(result.Value) ? result : Result.Failure<T>(error);
        }

        public static Result<TOut> Map<TIn, TOut>(
            this Result<TIn> result,
            Func<TIn, TOut> mappingFunc)
        {
            return result.IsSuccess
                ? Result.Success(mappingFunc(result.Value))
                : Result.Failure<TOut>(result.Error);
        }
    }
}