using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Resolutions.Server.Model.DTOs
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
