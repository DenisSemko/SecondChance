using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class DailyTestRepository : BaseRepository<DailyTest>, IDailyTestRepository
    {
        public DailyTestRepository(DatabaseContext databaseContext) : base(databaseContext) { }


    }
}
