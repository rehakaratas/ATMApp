using ATMApp.Domain.Entities;
using ATMApp.Domain.Repositories;
using ATMApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Infrastructure.Repositories
{
    public class UserRepo : BaseRepo<User> ,IUserRepo
    {
        public UserRepo(ATMAppDbContext atmAppDbContext) : base(atmAppDbContext)
        {

        }
    }
}
