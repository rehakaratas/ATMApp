using ATMApp.Application.Models.DTOs;
using ATMApp.Application.Services.TokenService;
using ATMApp.Domain.Entities;
using ATMApp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public UserService(ITokenHandler tokenHandler, IMapper mapper, IUserRepo userRepo)
        {
            _tokenHandler = tokenHandler;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task CreateUser(CreateUserDTO model)
        {
            var newUser = _mapper.Map<User>(model);
            await _userRepo.Create(newUser);
        }

        public async Task<Token> Login(LoginDTO model)
        {
            var user = await _userRepo.GetDefault(x => x.EmailAddress == model.EmailAddress && x.Password == model.Password);
            if (user != null)
            {
                Token token = _tokenHandler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(45);
                await _userRepo.Update(user);

                return token;
            }

            return null;
        }
    }
}
