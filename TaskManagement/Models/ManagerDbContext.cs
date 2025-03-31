using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options) { }
        public DbSet<Mission> Missions { get; set; }
    }
}
