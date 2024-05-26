using Todo.Domain.EntityBase;

namespace Todo.Domain.EntityModel
{
    public class TodoTask : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }        
       
    }
}