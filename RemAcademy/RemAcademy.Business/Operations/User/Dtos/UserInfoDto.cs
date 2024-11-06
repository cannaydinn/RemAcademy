using RemAcademy.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.User.Dtos
{
    public class UserInfoDto
    {
        private int id; 
        private string fullName;
        private string email;
        private string city;
        private string schoolName;
        private UserType userType;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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
        public UserType UserType
        {
            get { return userType; }
            set { userType = value; }
        }

    }
}
