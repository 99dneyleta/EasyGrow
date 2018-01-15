using EasyGrow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyGrow.Data
{
    public class PlantContext : IdentityDbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options) :
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<AdditinalCriteries> AdditinalCriteries { get; set; }
        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<GroundwaterLevel> GroundwaterLevels { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserPlants> UserPlants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPlants>()
                .HasKey(t => new { t.UserId, t.PlantId });


            modelBuilder.Entity<UserPlants>()
                .HasOne(sc => sc.Plant)
                .WithMany(c => c.UserPlants)
                .HasForeignKey(sc => sc.PlantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPlants>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany(s => s.UserPlants)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhasePlant>()
                .HasKey(t => new { t.PlantId, t.PhaseId });

            modelBuilder.Entity<PhasePlant>()
              .HasOne(sc => sc.Plant)
              .WithMany(c => c.PhasePlants)
              .HasForeignKey(sc => sc.PlantId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhasePlant>()
                .HasOne(sc => sc.Phase)
                .WithMany(s => s.PhasePlants)
                .HasForeignKey(sc => sc.PhaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plant>()
               .HasOne(sc => sc.AdditinalCriteries)
               .WithMany(s => s.Plants)
               .HasForeignKey(sc => sc.AdditinalCriteriesId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plant>()
               .HasOne(sc => sc.Class)
               .WithMany(s => s.Plants)
               .HasForeignKey(sc => sc.ClassId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
               .HasOne(sc => sc.Geolocation)
               .WithMany(s => s.ApplicationUsers)
               .HasForeignKey(sc => sc.GeolocationId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
               .HasOne(sc => sc.Plant)
               .WithMany(s => s.ApplicationUsers)
               .HasForeignKey(sc => sc.PlantId)
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
