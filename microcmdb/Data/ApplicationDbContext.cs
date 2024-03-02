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
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Host model definition
            builder.Entity<Models.Host>()
                .HasMany(h => h.Services)
                .WithOne(s => s.Host)
                .HasForeignKey(s => s.HostId);

            builder.Entity<Models.Host>()
                .HasOne(h => h.Node)
                .WithOne(n => n.Host)
                .HasForeignKey<Models.Host>(h => h.NodeId);

            // Service model definition

            builder.Entity<Service>()
                .HasOne(s => s.Host)
                .WithMany(h => h.Services)
                .HasForeignKey(s => s.HostId);

            // Software model definition            

            builder.Entity<Software>()
                .HasOne(s => s.Node)
                .WithMany(h => h.InstalledSoftware)
                .HasForeignKey(s => s.NodeId);

            // ConfigItem model definition

            builder.Entity<ConfigItem>().HasKey(h => h.ItemId);

            builder.Entity<ConfigItem>()
                .HasOne(h => h.Node)
                .WithOne(n => n.ConfigItem)
                .HasForeignKey<ConfigItem>(h => h.NodeId);

            // Node model definition

            builder.Entity<Node>().HasKey(n => n.Id);

            builder.Entity<Node>()
                .HasOne(n => n.ConfigItem)
                .WithOne(h => h.Node)
                .HasForeignKey<Node>(n => n.ConfigItemId);

            builder.Entity<Node>()
                .HasMany(h => h.InstalledSoftware)
                .WithOne(s => s.Node)
                .HasForeignKey(h => h.NodeId);

            builder.Entity<Node>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Node);

            builder.Entity<Node>()
                .HasOne(n => n.Host)
                .WithOne(h => h.Node)
                .HasForeignKey<Node>(n => n.HostId);

            // User model definition

            builder.Entity<User>().HasKey(u => u.UserId);

            builder.Entity<User>()
                .HasOne(e => e.Node)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.NodeId);

        }

        public DbSet<microcmdb.Models.ConfigItem> ConfigItem { get; set; } = default!;
    }
}
