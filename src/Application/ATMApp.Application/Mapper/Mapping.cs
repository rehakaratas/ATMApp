using ATMApp.Application.Models.DTOs;
using ATMApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<UserProcess, ProcessDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
        }
    }
}
