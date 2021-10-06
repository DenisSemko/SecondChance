using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserRole { get; set; }
    }
}
