using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.EntityModel;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure.Contracts;

namespace Todo.Application.Handlers.Contracts.UseCase.Task
{
    public class GetAllTaskHandler : IHandler<GetAllTaskRequest, CommonResponse>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<CommonResponse> Handle(GetAllTaskRequest request)
        {
            try
            {
                var task = await _taskRepository.GetAllTasks(request);
                return new CommonResponse
                {
                    StatusCode = "0",
                    Message = "Task fetched successfully",
                    Data = task.Select(x=> new{
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        DueDate = x.DueDate,
                        Status = Enum.GetName(typeof(Status), x.Status)

                    })
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