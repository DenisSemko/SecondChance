using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using System.Threading.Tasks;
using CIL.DTOs;
using DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Concrete
{
    public class ParentChildService : IParentChildService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DatabaseContext databaseContext;

        public ParentChildService(IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ParentChild>> Get()
        {
            return await unitOfWork.ParentChildRepository.Get();
        }

        public async Task<ParentChild> GetById(Guid id)
        {
            var result = await unitOfWork.ParentChildRepository.GetById(id);
            return result;
        }

        public async Task<ParentChild> Add(ParentChild parentChildUser)
        {
            var result = await unitOfWork.ParentChildRepository.Add(parentChildUser);
            return result;
        }

        public async Task<ParentChild> Add(ParentChildDto parentChildUser)
        {
            var parentUser = await databaseContext.Users.Where(x => x.Id == parentChildUser.Parent).FirstOrDefaultAsync();
            var childUser = await databaseContext.Users.Where(x => x.Id == parentChildUser.Child).FirstOrDefaultAsync();

            var parentChild = new ParentChild()
            {
                Id = parentChildUser.Id,
                ChildId = childUser,
                ParentId = parentUser
            };
            var result = await unitOfWork.ParentChildRepository.Add(parentChild);
            return result;
        }
    }
}
