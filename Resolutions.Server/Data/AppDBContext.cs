using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Resolutions.Server.Helpers;
using Resolutions.Server.Model;
using System.Reflection.Metadata;

namespace Resolutions.Server.Data
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}

        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<ResolutionEvent> Events { get; set; }
        public DbSet<ResolutionEventType> EventTypes { get; set; }
        public DbSet<BussinessConfigurationConstant> ConfigurationConstants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BussinessConfigurationConstant>()
                .HasKey(v => v.Name);

            modelBuilder.Entity<BussinessConfigurationConstant>().HasData(
                new BussinessConfigurationConstant() { Name = BussinessConstants.MaxResolutionsPerUser, Value = 3 },
                new BussinessConfigurationConstant() { Name = BussinessConstants.MaxEventTypesPerResolution, Value = 3 },
                new BussinessConfigurationConstant() { Name = BussinessConstants.MaxEventTypesPerResolution, Value = 1 });
        }
    }
}
