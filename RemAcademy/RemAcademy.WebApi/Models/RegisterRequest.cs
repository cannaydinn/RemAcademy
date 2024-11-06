using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RemAcademy.WebApi.Models
{
    public class RegisterRequest
    {
        private string fullName;
        private string email;
        private string password;
        private string city;
        private string schoolName;

        [Required]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

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
            
        [Required]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [Required]
        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }


    }
}
