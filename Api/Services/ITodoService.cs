using Demo.Api.Data.Entities;

namespace Demo.Api.Services;

public interface ITodoService
{
    Task<List<Todo>> GetAllAsync();
    Task SaveAsync(Todo newTodo);
}