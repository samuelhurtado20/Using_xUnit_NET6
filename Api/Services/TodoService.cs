using Demo.Api.Data;
using Demo.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;
    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _context.Todo.ToListAsync();
    }

    public async Task SaveAsync(Todo newTodo)
    {
        _context.Todo.Add(newTodo);
        await _context.SaveChangesAsync();
    }
}