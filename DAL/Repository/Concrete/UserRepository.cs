using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await databaseContext.Users
                .SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
