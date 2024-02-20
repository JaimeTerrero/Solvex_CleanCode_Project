using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtPlatform.Application.Users.DTOs;
using VirtPlatform.Application.Users.Helpers;
using VirtPlatform.Application.Users.Interfaces;
using VirtPlatform.Domain.Interfaces.Repositories.Users;
using VirtPlatform.Domain.Utils;

namespace VirtPlatform.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = PasswordHasher.HashPassword(userDto.Password);
            user.Token = GenerateJWT.GenerateToken(user);
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> Register(SignUp signUp)
        {
            var user = _mapper.Map<User>(signUp);
            user.Password = PasswordHasher.HashPassword(user.Password);
            user.Token = "";
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> Authenticate(LogIn logIn)
        {
            var user = await _userRepository.GetByEmailAsync(logIn.Email);

            user.Token = GenerateJWT.GenerateToken(user);

            return user;
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            var userList = await _userRepository.GetAllAsync();

            return userList;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            User usr = new();
            usr.Id = user.Id;
            usr.Name = user.Name;
            usr.LastName = user.LastName;
            usr.Email = user.Email;
            usr.Role = user.Role;

            return usr;
        }

        public async Task Update(int id, UserDto userDto)
        {
            User user = await _userRepository.GetByIdAsync(id);

            _mapper.Map(userDto, user);

            await _userRepository.UpdateAsync(user);
        }
    }
}
