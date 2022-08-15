using Demo.Api.Data.Entities;
using Demo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [Route("get-all")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _todoService.GetAllAsync();
        if (result.Count == 0)
        {
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> SaveAsync(Todo newTodo)
    {
        await _todoService.SaveAsync(newTodo);
        return Ok();
    }
}