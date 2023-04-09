using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCWeb.Models;

namespace MVCWeb.Data
{
    public class MVCWebDbContext : IdentityDbContext
    {
        public MVCWebDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MVCWebEntity> MVCWeb { get; set; }
    }
}
