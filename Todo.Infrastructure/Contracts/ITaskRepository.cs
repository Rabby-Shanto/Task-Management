using Todo.Domain.EntityModel;

using Todo.Domain.RequestModel.Task;

namespace Todo.Infrastructure.Contracts
{
    public interface ITaskRepository
    {
        Task<TodoTask> AddTask(AddTaskRequest request);
        Task<TodoTask> UpdateTask(UpdateTaskRequest request);
        Task<bool> DeleteTask(DeleteTaskRequest request);
        Task<TodoTask> GetTask(GetTaskRequest request);
        Task<IEnumerable<TodoTask>> GetAllTasks(GetAllTaskRequest request);
        Task<bool> BulkDeleteData(BulkDeleteRequest request);
        
    }
}