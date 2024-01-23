using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using microcmdb.Models;
using Microsoft.Extensions.Hosting;

namespace microcmdb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Accounts { get; set; }
        public DbSet<Models.Host> Hosts { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Software> Software { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Build a one-to-many relationship between Hosts and Services, so that a host can have multiple services
            builder.Entity<Models.Host>()
                .HasMany(h => h.Services)
                .WithOne(s => s.Host)
                .HasForeignKey(s => s.HostId);

            builder.Entity<Service>()
                .HasOne(s => s.Host)
                .WithMany(h => h.Services)
                .HasForeignKey(s => s.HostId);

            // Build a one-to-many relationship between Hosts and Software
            builder.Entity<Models.Host>()
                .HasMany(h => h.Software)
                .WithOne(s => s.Host)
                .HasForeignKey(s => s.HostId);

            builder.Entity<Software>()
                .HasOne(s => s.Host)
                .WithMany(h => h.Software)
                .HasForeignKey(s => s.HostId);

            // Build a one-to-one relationship between Nodes and Hosts, so that every host must have a node, but not every node needs a host
            builder.Entity<Models.Host>()

                .HasOne(h => h.Node)
                .WithOne(n => n.Host)
                .HasForeignKey<Models.Host>(h => h.NodeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Node>()
                .HasOne(n => n.Host)
                .WithOne(h => h.Node)
                .HasForeignKey<Models.Host>(n => n.NodeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Build a many-to-many relationship between Hosts and Users, so that a host can have multiple users, and a User can have multiple hosts
            builder.Entity<Models.Host>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Hosts);

            builder.Entity<User>()
                .HasMany(e => e.Hosts)
                .WithMany(e => e.Users);

        }
    }
}
