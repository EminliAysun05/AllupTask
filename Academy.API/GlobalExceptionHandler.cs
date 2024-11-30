using Academy.Application.Dtos;

namespace Academy.API
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<object>
                {
                    IsSucceed = false,
                    Message = "Error occured",
                };

                await context.Response.WriteAsJsonAsync(response); 
            }
        }
    }
}
