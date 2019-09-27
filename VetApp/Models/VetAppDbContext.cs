using Microsoft.EntityFrameworkCore;

namespace VetApp.Models
{
    public class VetAppDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=THINKPADDOPEDRO\SQLEXPRESS;Database=VetDataBase;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .IsRequired();

            modelBuilder.Entity<Owner>(o =>
            {
                o.Property(ow => ow.Name).IsRequired();
                o.Property(ow => ow.Birthday)
                    .HasColumnType("Date")
                    .IsRequired();
                o.Property(ow => ow.Contact).IsRequired();
            });

            modelBuilder.Entity<Pet>(a =>
            {
                a.Property(an => an.Name).IsRequired();
                a.Property(an => an.OwnerId).IsRequired();
                a.Property(an => an.Birthday)
                    .HasColumnType("Date")
                    .IsRequired();
                a.HasMany(p => p.Appointments).WithOne(ap => ap.Pet);
            });

            modelBuilder.Entity<Appointment>(a =>
            {
                a.Property(ap => ap.Date).IsRequired();
                a.Property(ap => ap.PetId).IsRequired();
                a.Property(ap => ap.DoctorId).IsRequired();
                
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(dc => dc.LicenseNumber);
                d.Property(dc => dc.Name).IsRequired();
                d.Property(dc => dc.Birthday).HasColumnType("Date").IsRequired();
                d.Property(dc => dc.Specialty).IsRequired();
                d.Property(dc => dc.Contact).IsRequired();
            });
        }
    }
}