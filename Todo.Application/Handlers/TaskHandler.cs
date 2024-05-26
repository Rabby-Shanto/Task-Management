using Todo.Application.Handlers.Contracts;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;

namespace Todo.Application.Handlers
{
    public class TaskHandler : ITaskHandler
    {
        private readonly IHandler<AddTaskRequest,CommonResponse> _addHandler;
        private readonly IHandler<GetTaskRequest,CommonResponse> _getHandler;
        private readonly IHandler<GetAllTaskRequest, CommonResponse> _getTasksHandler;
        private readonly IHandler<UpdateTaskRequest, CommonResponse> _updateTasksHandler;
        private readonly IHandler<DeleteTaskRequest, CommonResponse> _deleteTasksHandler;
        private readonly IHandler<BulkDeleteRequest, CommonResponse> _bulkDeleteHandler;

        public TaskHandler(IHandler<AddTaskRequest,CommonResponse> addHandler,
                IHandler<GetTaskRequest,CommonResponse> getHandler,
                IHandler<GetAllTaskRequest,CommonResponse> getTasksHandler,
                IHandler<UpdateTaskRequest,CommonResponse> updateHandler,
                IHandler<DeleteTaskRequest, CommonResponse> deleteTasksHandler,
                IHandler<BulkDeleteRequest, CommonResponse> bulkDeleteHandler){
                    _addHandler = addHandler;
                    _getHandler = getHandler;
                    _getTasksHandler = getTasksHandler;
                    _updateTasksHandler = updateHandler;
                    _deleteTasksHandler = deleteTasksHandler;
                    _bulkDeleteHandler = bulkDeleteHandler;

                }

        public async Task<CommonResponse> AddTask(AddTaskRequest request)
        {
            return await _addHandler.Handle(request);
        }

        public async Task<CommonResponse> BulkDeleteData(BulkDeleteRequest request)
        {
            return await _bulkDeleteHandler.Handle(request);
        }

        public async Task<CommonResponse> DeleteTask(DeleteTaskRequest request)
        {
            return await _deleteTasksHandler.Handle(request);
        }

        public async Task<CommonResponse> GetAllTasks(GetAllTaskRequest request)
        {
            return await _getTasksHandler.Handle(request);
        }

        public async Task<CommonResponse> GetTask(GetTaskRequest request)
        {
            return await _getHandler.Handle(request);
        }

        public async Task<CommonResponse> UpdateTask(UpdateTaskRequest request)
        {
            return await _updateTasksHandler.Handle(request);
        }
    }
}