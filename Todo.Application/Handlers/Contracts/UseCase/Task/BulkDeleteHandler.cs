using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.Task
{
    public class BulkDeleteHandler : IHandler<BulkDeleteRequest, CommonResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public BulkDeleteHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<CommonResponse> Handle(BulkDeleteRequest request)
        {
            try
            {
                var task = await _taskRepository.BulkDeleteData(request);
                return new CommonResponse
                {
                    StatusCode = "0",
                    Message = "Task deleted successfully",
                    Data = task
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