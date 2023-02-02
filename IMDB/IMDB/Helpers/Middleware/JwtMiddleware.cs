using IMDB.Helpers.Authorization;

namespace IMDB.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtUtils _jwtUtils;

        public JwtMiddleware(RequestDelegate next, JwtUtils jwtUtils)
        {
            _next = next;
            _jwtUtils = jwtUtils;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            if (token != null)
            {
                var userId = _jwtUtils.ValidateJwtToken(token);

                if (userId != Guid.Empty)
                {
                    context.Items.Add("userId", userId);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
