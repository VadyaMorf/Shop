using System.ComponentModel.DataAnnotations;

namespace Medteh.API.Contracts
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
}
