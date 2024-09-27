using Medteh.API.Contracts;
using Product.Application.Services;

namespace Medteh.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("register", Register);
            builder.MapPost("login", Login);
            return builder;
        }

        private static async Task<IResult> Register(RegisterUserRequest registerUserRequest,UserService userService)
        {
            await userService.Register(registerUserRequest.UserName, registerUserRequest.Email, registerUserRequest.Password);

            return Results.Ok();
        }
        private static async Task<IResult> Login(LoginUsersReauest request,UserService userService)
        {
            var token = userService.Login(request.Email,request.Password);

            return Results.Ok(token);
        }
    }
}
