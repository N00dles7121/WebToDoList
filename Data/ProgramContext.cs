using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class ProgramContext : DbContext
{
    public DbSet<TaskToDo> Tasks { get; set; } = null!;

    public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
    {

    }
}
