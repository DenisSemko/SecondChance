using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class UserPostDto
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserKnowledgeLevel { get; set; } = "A";
        public string UserRole { get; set; } = "User";
    }
}
