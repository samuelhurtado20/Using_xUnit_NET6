using Demo.Api.Data;
using Demo.Api.Services;
using Demo.TestApi.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Demo.TestApi.System.Services;

public class TestTodoService : IDisposable
{
    protected readonly AppDbContext _context;

    public TestTodoService()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
 
        _context = new AppDbContext(options);
 
        _context.Database.EnsureCreated();
    }
 
    [Fact]
    public async Task GetAllAsync_ReturnTodoCollection()
    {
        /// Arrange
        _context.Todo.AddRange(TodoMockData.GetTodos());
        _context.SaveChanges();
 
        var sut = new TodoService(_context);
 
        /// Act
        var result = await sut.GetAllAsync();
 
        /// Assert
        result.Should().HaveCount(TodoMockData.GetTodos().Count);
    }
 
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}