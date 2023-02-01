using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jobs.Models;
using System.Drawing.Drawing2D;

namespace Jobs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Users>? Users { get; set; }
    }
}