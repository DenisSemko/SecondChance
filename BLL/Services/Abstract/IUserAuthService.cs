using BLL.Domain;
using CIL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IUserAuthService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegisterModel user);
        Task<AuthenticationResult> LoginAsync(UserLoginModel user);
    }
}
