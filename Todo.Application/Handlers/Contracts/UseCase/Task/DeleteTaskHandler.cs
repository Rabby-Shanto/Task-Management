using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.Task
{
    public class DeleteTaskHandler : IHandler<DeleteTaskRequest, CommonResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<CommonResponse> Handle(DeleteTaskRequest request)
        {
            try
            {
                var task = await _taskRepository.DeleteTask(request);
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