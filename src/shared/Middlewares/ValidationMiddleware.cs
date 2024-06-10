using Microsoft.AspNetCore.Mvc;


namespace EstacionamentoAPI.Shared;
public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status400BadRequest && context.Items["ValidationProblemDetails"] is ValidationProblemDetails problemDetails)
        {
            var errors = new List<object>();

            foreach (var key in problemDetails.Errors.Keys)
            {
                errors.AddRange(problemDetails.Errors[key].Select(error => new { property = key, error }));
            }

            var result = new { errors };

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}