using Todo.Domain.RequestModel;

namespace Todo.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<bool> LogIn (LoginDto loginDto);
        Task<bool> Register (RegisterDto registerDto);
        
    }
}