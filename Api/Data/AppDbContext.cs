using Demo.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todo { get; set; }
}