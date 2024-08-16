using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsAcademy.Models;

namespace SportsAcademy.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<User> GetUsers { get; set; }

        public DbSet<Coach> Coachs { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<ContactUs> ContactUss { get; set; }

    }
}
