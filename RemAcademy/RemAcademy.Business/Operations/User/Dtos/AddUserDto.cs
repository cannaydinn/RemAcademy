using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.User.Dtos
{
    public class AddUserDto
    {
        private string fullName;
        private string email;
        private string password;
        private string city;
        private string schoolName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }
    }
}
