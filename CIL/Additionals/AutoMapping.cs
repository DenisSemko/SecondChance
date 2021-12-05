using AutoMapper;
using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Additionals
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDto, User>();
            CreateMap<QuestionDto, Question>();
            CreateMap<DailyTestResultDto, DailyTestResult>();
            CreateMap<ParentChildDto, ParentChild>();
            CreateMap<UserPostDto, User>();
        }
    }
}
