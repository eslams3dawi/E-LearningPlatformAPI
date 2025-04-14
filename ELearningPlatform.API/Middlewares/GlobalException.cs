namespace ELearningPlatform.API.Middlewares
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(RequestDelegate next, ILogger<GlobalException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception for {context.Request.Method}: {context.Request.Path}");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new { message = ex.Message };
                context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
