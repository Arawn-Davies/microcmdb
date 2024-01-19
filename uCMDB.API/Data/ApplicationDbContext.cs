using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using uCMDB.API.Models;

namespace uCMDB.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Service_Host> Hosts { get; set; }
        public DbSet<Service_Node> NetworkNodes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Software> Software { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
