using HighSkill.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSkill.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Course> Courses { get; set; }
    }
}