using Todo.Domain.EntityModel;

namespace Todo.Domain.RequestModel.Task
{
    public class GetAllTaskRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Status? Status { get; set; }
        public string Order { get; set; }
    }
}