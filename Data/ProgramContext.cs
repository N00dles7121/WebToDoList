using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class ProgramContext : DbContext
{
    public DbSet<TaskToDo> Tasks { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=WebAppDB;Trusted_Connection=True;Encrypt=False;");
    }
}
