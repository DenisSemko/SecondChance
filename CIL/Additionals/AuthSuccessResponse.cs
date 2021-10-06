using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Additionals
{
    public class AuthSuccessResponse
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string UserRole { get; set; }
    }
}
