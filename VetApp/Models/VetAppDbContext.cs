using Microsoft.EntityFrameworkCore;

namespace VetApp.Models
{
    public class VetAppDbContext : DbContext
    {

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Animals)
                .WithOne(a => a.Owner);

            modelBuilder.Entity<Owner>(o =>
            {
                o.Property(ow => ow.Name).IsRequired();
                o.Property(ow => ow.Birthday).IsRequired();
                o.Property(ow => ow.Contact).IsRequired();
                o.Property(ow => ow.Animals).IsRequired();

            });

            modelBuilder.Entity<Animal>(a =>
            {
                a.Property(an => an.Name).IsRequired();
                a.Property(an => an.Owner).IsRequired();
            });
        }
    }
}
