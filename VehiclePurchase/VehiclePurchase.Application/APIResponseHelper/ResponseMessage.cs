using System;
using System.Collections.Generic;
using VehiclePurchase.Application.Wrappers;

namespace VehiclePurchase.Application.APIResponseHelper
{
    public class ResponseMessage
    {
        public static Response<T> BadRequest<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.BadRequest));
        }
        public static Response<T> NotFound<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.NotFound));
        }
        public static Response<T> Forbidden<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.Forbidden));
        }
        public static Response<T> AlreadyExists<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.IsExist));
        }
        public static Response<T> InternalServerError<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.InternalServerError));
        }
        public static Response<T> Failed<T>(string message)
        {
            return NotSuccessfulGenericMessageHandler<T>(message, new List<string> { message }, Convert.ToInt32(StatusCodes.Failed));
        }
        public static Response<T> Successful<T>(T obj, string message)
        {
            return SuccessfulGenericMessageHandler<T>(obj, message, null, Convert.ToInt32(StatusCodes.OK));
        }





        public static Response<T> NotSuccessfulGenericMessageHandler<T>(string message, List<string> errors, int statusCode)
        {
            var response = new Response<T>
            {
                Data = default(T),
                Errors = errors,
                Message = message,
                StatusCode = statusCode,
                Succeeded = false
            };
            return response;
        }
        public static Response<T> SuccessfulGenericMessageHandler<T>(T obj, string message, List<string> errors, int statusCode)
        {
            var response = new Response<T>
            {
                Data = obj,
                Errors = errors,
                Message = message,
                StatusCode = statusCode,
                Succeeded = true
            };
            return response;
        }

    }

}
