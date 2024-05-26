using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        public string? Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}