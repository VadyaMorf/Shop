using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ShopDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Name = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }
    }
}
