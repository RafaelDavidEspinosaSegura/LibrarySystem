using Xunit;
using Moq;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsUsers()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<User> { new User("David","david@test.com") });

        var service = new UserService(mockRepo.Object);
        var result = await service.GetAllAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User)null);

        var service = new UserService(mockRepo.Object);
        var result = await service.GetByIdAsync(99);

        Assert.Null(result);
    }
}
