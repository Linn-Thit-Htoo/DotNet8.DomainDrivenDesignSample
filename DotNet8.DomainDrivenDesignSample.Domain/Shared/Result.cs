using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Domain.Shared
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError
        {
            get { return !IsSuccess; }
        }
        public EnumHttpStatusCode StatusCode { get; set; }

        public static Result<T> SuccessResult(
            string message = "Success.",
            EnumHttpStatusCode statusCode = EnumHttpStatusCode.Success
        )
        {
            return new Result<T>
            {
                IsSuccess = true,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static Result<T> SuccessResult(
            T data,
            string message = "Success.",
            EnumHttpStatusCode statusCode = EnumHttpStatusCode.Success
        )
        {
            return new Result<T>
            {
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static Result<T> FailureResult(
            string message = "Fail.",
            EnumHttpStatusCode statusCode = EnumHttpStatusCode.BadRequest
        )
        {
            return new Result<T>
            {
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static Result<T> FailureResult(
            Exception ex,
            EnumHttpStatusCode statusCode = EnumHttpStatusCode.InternalServerError
        )
        {
            return new Result<T>
            {
                Message = ex.ToString(),
                IsSuccess = false,
                StatusCode = statusCode
            };
        }

        public static Result<T> ExecuteResult(
            int result,
            EnumHttpStatusCode successStatusCode = EnumHttpStatusCode.Success,
            EnumHttpStatusCode failureStatusCode = EnumHttpStatusCode.BadRequest
        )
        {
            return result > 0
                ? Result<T>.SuccessResult(statusCode: successStatusCode)
                : Result<T>.FailureResult(statusCode: failureStatusCode);
        }
    }
}
