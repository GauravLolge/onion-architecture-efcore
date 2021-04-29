using CompanyName.MyAppName.Infra;
using CompanyName.MyAppName.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace CompanyName.MyAppName.WebApi.Common.Filters
{
    /// <summary>
    /// Provides member to handle excceltion across application.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
    public class CustomExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(NotImplementedException))
            {
                message = Constants.Error.ERROR_SERVER;
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(CustomException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }

            var error = new ErrorDetails()
            {
                StatusCode = (int)status,
                Message = message
            };

            context.Result = new JsonResult(error);
        }
    }
}
