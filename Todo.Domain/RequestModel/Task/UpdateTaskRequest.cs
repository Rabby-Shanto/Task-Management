using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel.Task
{
    public class UpdateTaskRequest
    {
        [Required]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

    }
}