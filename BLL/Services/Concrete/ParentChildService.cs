using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class ParentChildService : IParentChildService
    {
        private readonly IUnitOfWork unitOfWork;

        public ParentChildService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
    }
}
