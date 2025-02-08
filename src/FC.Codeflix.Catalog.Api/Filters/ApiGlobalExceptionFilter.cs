using FC.Codeflix.Catalog.Application.Exceptions;
using FC.Codeflix.Catalog.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FC.Codeflix.Catalog.Api.Filters;

public class ApiGlobalExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _env;
    public ApiGlobalExceptionFilter(IHostEnvironment env)
        => _env = env;

    public void OnException(ExceptionContext context)
    {
        var details = new ProblemDetails();
        var exception = context.Exception;

        if (_env.IsDevelopment())
            details.Extensions.Add("StackTrace", exception.StackTrace);

        switch (exception)
        {
            case EntityValidationException:
                details.Title = "One or more validation errors ocurred";
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = "UnprocessableEntity";
                details.Detail = exception!.Message;
                break;
            case NotFoundException:
                details.Title = "Not Found";
                details.Status = StatusCodes.Status404NotFound;
                details.Type = "NotFound";
                details.Detail = exception!.Message;
                break;
            case RelatedAggregateException:
                details.Title = "Invalid Related Aggregate";
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = "RelatedAggregate";
                details.Detail = exception!.Message;
                break;
            default:
                details.Title = "An unexpected error ocurred";
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = "UnexpectedError";
                details.Detail = exception.Message;
                break;
        }

        context.HttpContext.Response.StatusCode = (int)details.Status;
        context.Result = new ObjectResult(details);
        context.ExceptionHandled = true;
    }
}
