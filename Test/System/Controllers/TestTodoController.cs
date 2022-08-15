using Demo.Api.Controllers;
using Demo.Api.Services;
using Demo.TestApi.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Demo.TestApi.System.Controllers;

public class TestController
{
    [Fact]
    public async Task GetAllAsync_ShouldReturn200Status()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoMockData.GetTodos());

        var sut = new TodoController(todoService.Object);
 
        /// Act
        var result = (OkObjectResult)await sut.GetAllAsync();
 
 
        // /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn204NoContentStatus()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoMockData.GetEmptyTodos());
        var sut = new TodoController(todoService.Object);
 
        /// Act
        var result = (NoContentResult)await sut.GetAllAsync();
 
 
        /// Assert
        result.StatusCode.Should().Be(204);
        todoService.Verify(_ => _.GetAllAsync(),Times.Exactly(1));
    }
}


//// logger
//var mock = new Mock<ILogger<PermissionController>>();
//ILogger<PermissionController> logger = mock.Object;

//// uow
//var uow = new UnitOfWork(_context);

//// controller
//_controller = new PermissionController(logger, uow);