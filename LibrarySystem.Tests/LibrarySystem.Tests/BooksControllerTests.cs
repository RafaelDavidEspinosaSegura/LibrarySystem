using Xunit;
using Moq;
using LibrarySystem.Api.Controllers;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BooksControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOk_WithBooks()
    {
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Book> { new Book { Id = 1, Title = "Test Book" } });

        var controller = new BooksController(mockRepo.Object);

        var result = await controller.GetAll();


        var okResult = Assert.IsType<OkObjectResult>(result);
        var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        Assert.Single(books);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var mockRepo = new Mock<IBookRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Book)null);

        var controller = new BooksController(mockRepo.Object);

        var result = await controller.GetById(99);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction()
    {
        var mockRepo = new Mock<IBookRepository>();
        var book = new Book { Id = 1, Title = "Nuevo Libro" };

        mockRepo.Setup(r => r.AddAsync(book)).Returns(Task.CompletedTask);

        var controller = new BooksController(mockRepo.Object);

        var result = await controller.Create(book);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetById", createdResult.ActionName);
        Assert.Equal(book, createdResult.Value);
    }
}
