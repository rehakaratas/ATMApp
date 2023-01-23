using ATMApp.Application.Models.DTOs;
using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.UserProcessService
{
    public interface IUserProcessService
    {
        Task<decimal> GetUserBalance(int userId);
        Task<UserProcess> AddUserProcess(ProcessDTO model, int UserId);
    }
}
