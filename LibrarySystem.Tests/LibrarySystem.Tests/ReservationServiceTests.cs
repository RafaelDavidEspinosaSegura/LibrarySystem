using Xunit;
using Moq;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReservationServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsReservations()
    {
        var mockRepo = new Mock<IReservationRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Reservation> { new Reservation(1, DateTime.Now) });

        var service = new ReservationService(mockRepo.Object);
        var result = await service.GetAllAsync();

        Assert.Single(result);
    }
}
