using FluentValidation;
using RideShare.Api.Models;
using RideShare.Domain.Exceptions;

namespace RideShare.Api.Middlewares;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate request)
    {
        _next = request;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (EntityDoesNotExistException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var message = string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException.Message;
            var response = new ResponseModel(message);
            await httpContext.Response.WriteAsJsonAsync(response);
        }
        catch (DomainException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var message = string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException.Message;
            var response = new ResponseModel(message);
            await httpContext.Response.WriteAsJsonAsync(response);

        }
        catch (ValidationException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var message = string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException.Message;
            var response = new ResponseModel(message);
            await httpContext.Response.WriteAsJsonAsync(response);

        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var message = string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.Message : ex.InnerException.Message;
            var response = new ResponseModel(message);
            await httpContext.Response.WriteAsJsonAsync(response);


        }
    }

}