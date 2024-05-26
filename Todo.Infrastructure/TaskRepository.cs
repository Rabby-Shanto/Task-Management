using Todo.Domain.EntityModel;
using Todo.Domain.RequestModel.Task;
using Todo.Infrastructure.Contracts;
using Todo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure
{
    public class TaskRepository(DatabaseContext databaseContext) : ITaskRepository
    {
        private readonly DatabaseContext _context = databaseContext;

        public async Task<TodoTask> AddTask(AddTaskRequest request)
        {
            var task = new TodoTask
            {
                Title = request.Title,
                Description = request.Description,
                CreatedDate = DateTime.UtcNow,
                DueDate = request.DueDate,
                UserId = request.UserId,
                Status = GetStatus(request.DueDate)
            };
            _context.TodoItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        private Status GetStatus(DateTime dueDate)
        {
            return dueDate < DateTime.UtcNow ? Status.InComplete : Status.InProgress;
        }

        public async Task<bool> BulkDeleteData(BulkDeleteRequest request)
        {
            try
            {
                var items = _context.TodoItems.Where(x => request.TaskIds.Contains(x.Id));
                _context.TodoItems.RemoveRange(items);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteTask(DeleteTaskRequest request)
        {
            try
            {
                var item = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (item != null)
                {
                    _context.TodoItems.Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks(GetAllTaskRequest request)
        {
            var query = _context.TodoItems.AsQueryable();

            if (request.Status.HasValue)
            {
                query = query.Where(x => x.Status == request.Status.Value);
            }

            var tasks = await query
                .OrderBy(x=> x.Status)
                .ToListAsync();

            return tasks;
        }

        public async Task<TodoTask> GetTask(GetTaskRequest request)
        {
            var task = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Id);
            return task!;
        }

        public async Task<TodoTask> UpdateTask(UpdateTaskRequest request)
        {
            var task = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == request.TaskId);
            if (task != null)
            {
                task.Title = request.Title;
                task.Description = request.Description;
                task.DueDate = request.DueDate;
                task.Status = Enum.Parse<Status>(request.Status);
                await _context.SaveChangesAsync();
            }
            return task!;
        }
    }
}
