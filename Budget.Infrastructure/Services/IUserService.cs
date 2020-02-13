using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budget.Infrastructure.DTO;

namespace Budget.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> BrowseAsync();

        Task RegisterAsync(Guid userId, string email, string firstname, string lastname,
            string password);

        Task LoginAsync(string email, string password);
    }
}