﻿using RemAcademy.Data.Enums;

namespace RemAcademy.WebApi.Jwt
{
    public class JwtDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string SchoolName { get; set; }
        public UserType UserType { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
    } 
}
