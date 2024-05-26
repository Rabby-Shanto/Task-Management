using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel.Task
{
    public class GetTaskRequest
    {
        [Required]
        public int Id { get; set; }
    }
}