﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetApp.Models;

namespace VetApp.Migrations
{
    [DbContext(typeof(VetAppDbContext))]
    partial class VetAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VetApp.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("DoctorId");

                    b.Property<int>("PetId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PetId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("VetApp.Models.Doctor", b =>
                {
                    b.Property<int>("LicenseNumber");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Specialty");

                    b.HasKey("LicenseNumber");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("VetApp.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("VetApp.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OwnerId");

                    b.Property<int>("PetType");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VetApp.Models.Appointment", b =>
                {
                    b.HasOne("VetApp.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VetApp.Models.Pet", "Pet")
                        .WithMany("Appointments")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VetApp.Models.Pet", b =>
                {
                    b.HasOne("VetApp.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
