using System.ComponentModel.DataAnnotations;

namespace Medteh.API.Contracts
{
    public record LoginUsersReauest(
        [Required] string Email,
        [Required] string Password);
}
