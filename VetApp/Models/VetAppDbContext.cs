using Microsoft.EntityFrameworkCore;

namespace VetApp.Models
{
    public class VetAppDbContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=THINKPADDOPEDRO\SQLEXPRESS;Database=VetDataBase;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets);

            modelBuilder.Entity<Owner>(o =>
            {
                o.Property(ow => ow.Name).IsRequired();
                o.Property(ow => ow.Birthday).IsRequired();
                o.Property(ow => ow.Contact).IsRequired();

            });

            modelBuilder.Entity<Pet>(a =>
            {
                a.Property(an => an.Name).IsRequired();
                a.Property(an => an.OwnerId).IsRequired();
            });
        }
    }
}
