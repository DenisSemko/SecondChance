using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
