namespace Todo.Domain.RequestModel.Task
{
    public class AddTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }      
    }
}