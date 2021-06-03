using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MMM.Test.Core.Models;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using System;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Api.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BrokenCircuitException ex)
            {
                string info = "Circuit Breaker Policy Exception captured.";
                await HandleExceptionAsync(httpContext, ex, info);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, "Unespected error! Exception not handled!");
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, string additionalInformation)
        {
            _logger.LogError(exception, $"{exception.GetType().Name} captured.");

            context.Response.StatusCode = context.Response.StatusCode;

            ApiResponse<ErrorDetails> apiResponse = new ApiResponse<ErrorDetails>
            {
                Success = false,
                Response = GetErrorDetails(exception, additionalInformation)
            };

            string result = JsonConvert.SerializeObject(apiResponse);
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }

        private ErrorDetails GetErrorDetails(Exception exception, string additionalInformation)
        {
            ErrorDetails error = new ErrorDetails
            {
                AdditionalInformation = additionalInformation,
                ExceptionType = exception.GetType().FullName,
                Message = exception.Message,
                Source = exception.Source,
                TimeStamp = DateTime.Now
            };

            return error;
        }
    }
}
