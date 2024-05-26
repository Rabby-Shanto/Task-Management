using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel.Task
{
    public class DeleteTaskRequest
    {
        [Required]
        public int Id { get; set; }
    }
}