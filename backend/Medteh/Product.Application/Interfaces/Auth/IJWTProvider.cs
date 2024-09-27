using Shop.Core.Models;

namespace Product.Application.Inerfaces.Auth
{
    public interface IJWTProvider
    {
        string GenerateToken(User user);
    }
}