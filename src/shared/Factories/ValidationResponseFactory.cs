using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Shared
{
    public static class ValidationResponseFactory
    {
        public static IActionResult CreateValidationResponse(ActionContext context)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new
                {
                    property = x.Key,
                    errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                })
                .ToArray();

            var result = new
            {
                errors
            };

            return new BadRequestObjectResult(result)
            {
                ContentTypes = { "application/json" }
            };
        }
    }
}