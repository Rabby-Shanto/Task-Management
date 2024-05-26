using Todo.Application.Handlers.Contracts;
using Todo.Domain.RequestModel;
using Todo.Domain.ResponseModel;

namespace Todo.Application.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly IHandler<RegisterDto, CommonResponse> _addUserHandler;
        private readonly IHandler<LoginDto, CommonResponse> _loginHandler;
        public UserHandler(IHandler<RegisterDto, CommonResponse> addUserHandler, IHandler<LoginDto, CommonResponse> loginHandler)
        {
            _addUserHandler = addUserHandler;
            _loginHandler = loginHandler;
        }
        public async Task<CommonResponse> RegisterUser(RegisterDto request)
        {
            try
            {
                return await _addUserHandler.Handle(request);
            }
            catch (Exception ex)
            {
                return new CommonResponse
                {
                    StatusCode = "1",
                    Message = ex.Message
                };
            }
        }
        public async Task<CommonResponse> LoginUser(LoginDto request)
        {
            try
            {
                return await _loginHandler.Handle(request);
            }
            catch (Exception ex)
            {
                return new CommonResponse
                {
                    StatusCode = "1",
                    Message = ex.Message
                };
            }
        }
        
    }
}