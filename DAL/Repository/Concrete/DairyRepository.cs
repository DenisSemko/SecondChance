using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class DairyRepository : BaseRepository<Dairy>, IDairyRepository
    {
        public DairyRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
