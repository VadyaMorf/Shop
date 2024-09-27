using Shop.Core.Models;
using Shop.DataAccess.Repositories;
using Product.Application.Inerfaces.Auth;

namespace Product.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _repository;
        private readonly IJWTProvider _provider;
        public UserService(IUserRepository repository, IPasswordHasher passwordHasher, IJWTProvider provider)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _provider = provider;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashPassword);  

            await _repository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _repository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if(result == false)
            {
                throw new Exception();
            }

            var token = _provider.GenerateToken(user);
            return token;
        }
    }
}
