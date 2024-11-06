using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemAcademy.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        private string fullName;
        private string schoolName;
        private string city;
        private string email;
        private string password;
        private UserType userType;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
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

        public UserType UserType
        {
            get{ return userType; }
            set { userType = value; }

        }
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired();
            builder.Property(x=>x.SchoolName)
                .IsRequired();
            builder.Property(x=>x.City)
                .IsRequired();
            builder.Property(x=>x.Email)
                .IsRequired();
            builder.Property(x=>x.Password)
                .IsRequired();

            base.Configure(builder);
        }
    }

}
