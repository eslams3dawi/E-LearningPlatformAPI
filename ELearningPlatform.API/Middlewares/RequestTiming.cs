using System;
using System.Diagnostics;

namespace ELearningPlatform.API.Middlewares
{
    public class RequestTiming
    {
        private readonly RequestDelegate _next;

        public RequestTiming(RequestDelegate next)//Can call the next middleware through RequestDelegate
        {
            _next = next;
        }
        //Create method that will apply to before calling this middleware & after
        public async Task InvokeAsync(HttpContext context)
        {
            //Before
            var stopWatch = Stopwatch.StartNew();

            //Call next
            await _next(context);
            //After

            stopWatch.Stop();
            var elapsedMs = stopWatch.ElapsedMilliseconds;

            //Old Logic
            //context.Response.Headers.Add("Execution-Time-ms", elapsedMs.ToString());
                //The header may be added to the response after the response was sent or while sending it (Conflict)
                //Then will return empty body(invalid response)

            //New Logic
                //Then check first that the response it not be sent yet
            if (!context.Response.HasStarted)
            {
                context.Response.Headers.Add("Execution-Time-ms", elapsedMs.ToString());
            }
        }
    }
}
