﻿using Microsoft.EntityFrameworkCore;

namespace VetApp.Models
{
    public class VetAppDbContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=VetDb;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Pets)
                .WithOne(a => a.Owner);

            modelBuilder.Entity<Owner>(o =>
            {
                o.Property(ow => ow.Name).IsRequired();
                o.Property(ow => ow.Birthday).IsRequired();
                o.Property(ow => ow.Contact).IsRequired();
                o.Property(ow => ow.Pets).IsRequired();

            });

            modelBuilder.Entity<Pet>(a =>
            {
                a.Property(an => an.Name).IsRequired();
                a.Property(an => an.Owner).IsRequired();
            });
        }
    }
}
