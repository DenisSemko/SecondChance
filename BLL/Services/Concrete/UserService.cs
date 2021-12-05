using AutoMapper;
using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using DAL;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly DatabaseContext databaseContext;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await unitOfWork.UserRepository.Get();
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await unitOfWork.UserRepository.GetById(id);
            return result;
        }

        public async Task<User> Add(UserPostDto userDto)
        {
            var user = new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Surname = userDto.Surname,
                BirthDate = userDto.BirthDate,
                UserName = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                UserKnowledgeLevel = userDto.UserKnowledgeLevel,
                UserRole = userDto.UserRole
            };
            var result = await unitOfWork.UserRepository.Add(user);
            return result;
        }

        public async Task<User> Update(User user)
        {
            var result = await unitOfWork.UserRepository.Update(user);
            return result;
        }
        public async Task<User> Update(UserDto userDto)
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(userDto.Username);
            mapper.Map(userDto, user);
            await unitOfWork.UserRepository.Update(user);
            return user;
        }

        public async Task<User> DeleteById(Guid id)
        {
            var result = await unitOfWork.UserRepository.DeleteById(id);
            return result;
        }
    }
}
