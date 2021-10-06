using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserByUsernameAsync(string username);
    }
}
