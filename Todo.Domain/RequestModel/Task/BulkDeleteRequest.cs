using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel.Task
{
    public class BulkDeleteRequest
    {
        [Required]
        public List<int> TaskIds { get; set; }
    }
}