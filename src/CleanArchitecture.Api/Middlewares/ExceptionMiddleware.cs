using CleanArchitecture.Application.Exceptions;
using FluentValidation;
using System.Net;

namespace CleanArchitecture.Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            string errorId = Guid.NewGuid().ToString();

            var errorResult = new ErrorResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName,
                Exception = exception.Message.Trim(),
                ErrorId = errorId,
                SupportMessage = $"Provide the ErrorId {errorId} to the support team for further analysis."
            };

            errorResult.Messages.Add(exception.Message.Trim());

            if (exception is not CustomException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            if (exception is ValidationException fluentException)
            {
                errorResult.Exception = "One or More Validations failed.";
                foreach (var error in fluentException.Errors)
                {
                    errorResult.Messages.Add(error.ErrorMessage);
                }
            }

            switch (exception)
            {
                case CustomException e:
                    errorResult.StatusCode = (int)e.StatusCode;
                    if (e.ErrorMessages is not null)
                    {
                        errorResult.Messages = e.ErrorMessages;
                    }

                    break;

                case KeyNotFoundException:
                    errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case ValidationException:
                    errorResult.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError($"{errorResult.Exception} Request failed with Status Code {errorResult.StatusCode} and Error Id {errorId}.");
            var response = context.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = errorResult.StatusCode;
                await response.WriteAsJsonAsync(errorResult);
            }
            else
            {
                _logger.LogWarning("Can't write error response. Response has already started.");
            }
        }
    }
}