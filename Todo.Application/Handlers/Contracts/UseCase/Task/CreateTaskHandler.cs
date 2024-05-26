using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.Task
{
    public class CreateTaskHandler : IHandler<AddTaskRequest, CommonResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<CommonResponse> Handle(AddTaskRequest request)
        {
            try
            {
                var task = await _taskRepository.AddTask(request);
                return new CommonResponse
                {
                    StatusCode = "0",
                    Message = "Task created successfully",
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