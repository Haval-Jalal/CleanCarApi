using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanCarApi.API.Middleware;

// Fångar alla okantade undantag och returnerar rätt HTTP-statuskod
public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, message) = exception switch
        {
            ValidationException ex => (
                StatusCodes.Status400BadRequest,
                string.Join(", ", ex.Errors.Select(e => e.ErrorMessage))),

            KeyNotFoundException => (
                StatusCodes.Status404NotFound,
                exception.Message),

            UnauthorizedAccessException => (
                StatusCodes.Status401Unauthorized,
                exception.Message),

            _ => (
                StatusCodes.Status500InternalServerError,
                "Ett oväntat fel inträffade.")
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = statusCode,
                Detail = message
            },
            cancellationToken);

        return true;
    }
}
