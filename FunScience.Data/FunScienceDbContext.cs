namespace FunScience.Data
{
    using FunScience.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FunScienceDbContext : IdentityDbContext<User>
    {
        public FunScienceDbContext(DbContextOptions<FunScienceDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Play> Plays { get; set; }

        public DbSet<Performance> Performances { get; set; }

        public int MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Play>()
               .HasIndex(u => u.Name)
               .IsUnique();

            builder.Entity<School>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<School>()
                .Property(s => s.Lat)
                .HasColumnType("decimal(10,6)")
                .IsRequired(true);

            builder.Entity<School>()
                .Property(s => s.Lng)
                .HasColumnType("decimal(10,6)")
                .IsRequired(true);

            builder
                 .Entity<UserPerformance>()
                 .HasKey(u => new { u.UserId, u.PerformanceId });

            builder
                .Entity<UserPerformance>()
                .HasOne(up => up.User)
                .WithMany(u => u.Performances)
                .HasForeignKey(up => up.UserId);

            builder
                .Entity<UserPerformance>()
                .HasOne(up => up.Performance)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PerformanceId);

            builder.Entity<Performance>()
                .HasOne(p => p.Play)
                .WithMany(pl => pl.Performances)
                .HasForeignKey(p => p.PlayId);

            builder.Entity<Performance>()
               .HasOne(p => p.School)
               .WithMany(s => s.Performances)
               .HasForeignKey(p => p.SchoolId);

            base.OnModelCreating(builder);
        }
    }
}
