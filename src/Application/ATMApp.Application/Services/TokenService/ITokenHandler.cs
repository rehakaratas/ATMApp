using ATMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.TokenService
{
    public interface ITokenHandler
    {
        public Token CreateAccessToken(User user);
        public string CreateRefreshToken();

    }
}
