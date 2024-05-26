using Todo.Domain.RequestModel;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.User
{
    public class RegistrationHandler : IHandler<RegisterDto, CommonResponse>
    {
        private readonly IUserRepository _userRepository;
        public RegistrationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CommonResponse> Handle(RegisterDto request)
        {
            try
            {
                var user = await _userRepository.Register(request);
                return new CommonResponse
                {
                    StatusCode = "0",
                    Message = "User registered successfully",
                    Data = user
                };
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