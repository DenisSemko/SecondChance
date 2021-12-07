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

        public async Task<ParentChild> GetByParentId(Guid id)
        {
            var result = await databaseContext.ParentChild.Where(o => o.Parent.Id == id).Include(o => o.ChildList).FirstOrDefaultAsync();
            return result;
        }
        public async Task<ParentChild> DeleteByChildId(Guid id)
        {
            var result = await databaseContext.ParentChild.Where(o => o.Child.Id == id).FirstOrDefaultAsync();
            databaseContext.Set<ParentChild>().Remove(result);
            await databaseContext.SaveChangesAsync();
            return result;
        }
    }
}
