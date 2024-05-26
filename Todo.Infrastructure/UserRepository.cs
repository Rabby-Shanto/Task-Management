using Microsoft.EntityFrameworkCore;
using Todo.Domain.EntityModel;
using Todo.Domain.RequestModel;
using Todo.Infrastructure.Contracts;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> LogIn(LoginDto loginDto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);
                if (user != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            try {
                var user = new User
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    CreatedDate = DateTime.UtcNow
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch {
                throw;
            }
           
        }
    }
}