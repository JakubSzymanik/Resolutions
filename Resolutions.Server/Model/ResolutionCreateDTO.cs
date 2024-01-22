using System.ComponentModel.DataAnnotations;

namespace Resolutions.Server.Model
{
    public class ResolutionCreateDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}
