using Microsoft.EntityFrameworkCore;
using NewCrud.Models;

namespace NewCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Evento> eventos { get; set; }
    }
}
