using EasyGrow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyGrow.Data
{
    public sealed class PlantContext : IdentityDbContext
    {
        public PlantContext(DbContextOptions options) :
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
        public DbSet<UserPlantPhaseGeo> UserPlantPhaseGeo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPlantPhaseGeo>()
                .HasKey(t => new { t.UserId, t.PlantId, t.PhaseId, t.GeolocationId });


            modelBuilder.Entity<UserPlantPhaseGeo>()
                .HasOne(sc => sc.Plant)
                .WithMany(c => c.UserPlantPhaseGeo)
                .HasForeignKey(sc => sc.PlantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPlantPhaseGeo>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany(s => s.UserPlantPhaseGeo)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPlantPhaseGeo>()
                .HasOne(o => o.Phase)
                .WithMany(m => m.UserPlantPhaseGeo)
                .HasForeignKey(o => o.PhaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPlantPhaseGeo>()
                .HasOne(o => o.Geolocation)
                .WithMany(m => m.UserPlantPhaseGeo)
                .HasForeignKey(o => o.GeolocationId)
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

        }
    }
}
