using System.ComponentModel.DataAnnotations;
using Todo.Domain.EntityBase;

namespace Todo.Domain.EntityModel
{
    public class User : Entity
    {
        [Required]
        public string UserName { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}