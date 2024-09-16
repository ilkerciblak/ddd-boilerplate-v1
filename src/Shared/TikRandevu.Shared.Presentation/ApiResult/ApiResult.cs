using Microsoft.AspNetCore.Http;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Presentation.ApiResult;

public static class ApiResult
{
    public static IResult Problem(Result result)
    {
        return Microsoft.AspNetCore.Http.Results.Problem(
            statusCode: GetStatusCode(result.Error.ErrorType),
            title: GetTitle(result.Error),
            type: GetType(result.Error.ErrorType),
            detail: GetDetail(result.Error),
            extensions: GetExtensions(result.Error)
        );

        static int GetStatusCode(ErrorType errorType)
            => errorType switch
            {
                ErrorType.Problem => StatusCodes.Status400BadRequest,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,
                ErrorType.Validation => StatusCodes.Status422UnprocessableEntity,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        static string GetTitle(Error error)
            => error.ErrorType switch
            {
                ErrorType.Problem => error.Code,
                ErrorType.Failure => error.Code,
                ErrorType.Validation => error.Code,
                ErrorType.NotFound => error.Code,
                ErrorType.Conflict => error.Code,
                _ => "UnexpectedError"
            };

        static string GetDetail(Error error)
            => error.ErrorType switch
            {
                ErrorType.Problem => error.Description,
                ErrorType.Failure => error.Description,
                ErrorType.Validation => error.Description,
                ErrorType.NotFound => error.Description,
                ErrorType.Conflict => error.Description,
                _ => "UnexpectedError"
            };

        static string GetType(ErrorType errorType)
            => errorType switch
            {
                ErrorType.Problem => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400",
                ErrorType.Failure => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500",
                ErrorType.Validation => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/422",
                ErrorType.NotFound => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404",
                ErrorType.Conflict => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/409",
                _ => "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500"
            };

        static Dictionary<string, object?>? GetExtensions(Error error)
        {
            Dictionary<string, object?>? extensions = new Dictionary<string, object?>();

            if (error is ValidationError validationError)
            {
                extensions.Add("Errors", validationError.Errors);
            }

            return extensions;
        }
    }
}