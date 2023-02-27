using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required] public string KnownAs { get; set; }
        [Required] public string Gender { get; set; }
        // weird workaround to make the required attribute working
        [Required] public DateOnly? DateOfBirth { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

    }
}