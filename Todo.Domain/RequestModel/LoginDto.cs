using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.RequestModel
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
