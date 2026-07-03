using Xunit;
using Moq;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookServiceTests
{
    [Fact]
    public async Task GetAllBooksAsync_ReturnsBooks()
    {
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Book> { new Book { Id = 1, Title = "Test Book", ISBN = "123", PublicationDate = DateTime.Now, CategoryId = 1 } });

        var service = new BookService(mockRepo.Object);

        var result = await service.GetAllBooksAsync();

        Assert.Single(result);
        Assert.Equal("Test Book", result.First().Title);
    }

    [Fact]
    public async Task GetBookByIdAsync_ReturnsNull_WhenBookNotFound()
    {
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Book)null);

        var service = new BookService(mockRepo.Object);

        var result = await service.GetBookByIdAsync(99);

        Assert.Null(result);
    }

    [Fact]
    public async Task AddBookAsync_CallsRepositoryAdd()
    {
        var mockRepo = new Mock<IBookRepository>();
        var book = new Book("Nuevo Libro", "123", DateTime.Now, 1);

        var service = new BookService(mockRepo.Object);

        await service.AddBookAsync(book);

        mockRepo.Verify(r => r.AddAsync(book), Times.Once);
    }
}
