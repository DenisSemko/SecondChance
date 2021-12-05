using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    public class ParentChildRepository : BaseRepository<ParentChild>, IParentChildRepository
    {
        public ParentChildRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<ParentChild>> GetByParentId(Guid id)
        {
            var result = await databaseContext.ParentChild.Where(o => o.Parent.Id == id).Include(o => o.Child).ToListAsync();
            return result;
        }
    }
}
