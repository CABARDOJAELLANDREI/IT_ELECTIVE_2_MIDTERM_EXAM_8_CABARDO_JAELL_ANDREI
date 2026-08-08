using System.ComponentModel.DataAnnotations;

namespace ConferenceSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(30, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}