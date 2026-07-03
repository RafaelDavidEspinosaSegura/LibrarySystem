using Xunit;
using Moq;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LoanServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsLoans()
    {
        var mockRepo = new Mock<ILoanRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Loan> { new Loan(1, DateTime.Now) });

        var service = new LoanService(mockRepo.Object);
        var result = await service.GetAllAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
    {
        var mockRepo = new Mock<ILoanRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Loan)null);

        var service = new LoanService(mockRepo.Object);
        var result = await service.GetByIdAsync(99);

        Assert.Null(result);
    }
}
