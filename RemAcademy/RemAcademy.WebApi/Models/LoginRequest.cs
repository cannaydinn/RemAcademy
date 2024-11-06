using System.ComponentModel.DataAnnotations;

namespace RemAcademy.WebApi.Models
{
    public class LoginRequest
    {
        private string email;
        private string password;

        [Required]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
