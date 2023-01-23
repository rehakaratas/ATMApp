using ATMApp.Application.Models.DTOs;
using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.UserService
{
    public interface IUserService
    {
        Task<Token> Login(LoginDTO model);
        Task CreateUser(CreateUserDTO model);

    }
}
