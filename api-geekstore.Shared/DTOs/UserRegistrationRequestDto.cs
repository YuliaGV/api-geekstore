
using System.ComponentModel.DataAnnotations;


namespace api_geekstore.Shared.DTOs
{
    public class UserRegistrationRequestDto
    {
        [Required]
        [MaxLength(250, ErrorMessage ="Name can't have more than 250 characteres")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
