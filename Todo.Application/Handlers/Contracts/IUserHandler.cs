using Todo.Domain.RequestModel;
using Todo.Domain.ResponseModel;

namespace Todo.Application.Handlers.Contracts
{
    public interface IUserHandler
    {
        Task<CommonResponse> RegisterUser(RegisterDto register);
        Task<CommonResponse> LoginUser(LoginDto login);
        
    }
}