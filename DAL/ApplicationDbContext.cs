using MarotiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MarotiDemo.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base (options)
        {
            
        }
        public DbSet <Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
