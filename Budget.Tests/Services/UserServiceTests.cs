using System;
using System.Threading.Tasks;
using AutoMapper;
using Budget.Core.Domain;
using Budget.Core.Repositories;
using Budget.Infrastructure.Services;
using Moq;
using Xunit;

namespace Budget.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository_once()
        {
            var userRepositoryMock = new  Mock<IUserRepository>();
            var mapperMock = new  Mock<IMapper>();
            
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync(new Guid(), "user@email.com", "Adam", "Culson", "secret");
            
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}