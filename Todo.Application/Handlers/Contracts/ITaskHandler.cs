using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;

namespace Todo.Application.Handlers.Contracts
{
    public interface ITaskHandler
    {
        Task<CommonResponse> AddTask(AddTaskRequest request);
        Task<CommonResponse> UpdateTask(UpdateTaskRequest request);
        Task<CommonResponse> DeleteTask(DeleteTaskRequest request);
        Task<CommonResponse> GetTask(GetTaskRequest request);
        Task<CommonResponse> GetAllTasks(GetAllTaskRequest request);
        Task<CommonResponse> BulkDeleteData (BulkDeleteRequest request);
        
    }
}