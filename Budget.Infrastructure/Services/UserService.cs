using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Budget.Core.Domain;
using Budget.Core.Repositories;
using Budget.Infrastructure.DTO;

namespace Budget.Infrastructure.Services
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
        
        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task RegisterAsync(Guid userId, string email, string firstname, string lastname, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception(); // TODO
            }

            var salt = password;
            user = new User(userId, email, password, salt, firstname, lastname);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception(); // TODO
            }
            
            if (user.Password == password)
            {
                return;    
            }
            throw new Exception(); // TODO
        }
    }
}