using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.Task
{
    public class GetTaskHandler : IHandler<GetTaskRequest, CommonResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<CommonResponse> Handle(GetTaskRequest request)
        {
            try
            {
                var task = await _taskRepository.GetTask(request);
                return new CommonResponse
                {
                    StatusCode = "0",
                    Message = "Task fetched successfully",
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