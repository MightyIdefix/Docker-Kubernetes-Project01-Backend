﻿// <auto-generated />
using DISPBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DISPBackEnd.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210315123720_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DISPBackEnd.Models.HaandVaerker", b =>
                {
                    b.Property<int>("HaandVaerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HaandVaerkerId");

                    b.ToTable("HaandVaerkers");
                });

            modelBuilder.Entity("DISPBackEnd.Models.Vaerktoej", b =>
                {
                    b.Property<int>("VaerktoejId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Liggerlvtk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTAnskaffet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTSerieNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaerktoejskasseId")
                        .HasColumnType("int");

                    b.HasKey("VaerktoejId");

                    b.HasIndex("VaerktoejskasseId");

                    b.ToTable("Vaerktoejs");
                });

            modelBuilder.Entity("DISPBackEnd.Models.Vaerktoejskasse", b =>
                {
                    b.Property<int>("VaerktoejskasseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HaandVaerkerId")
                        .HasColumnType("int");

                    b.Property<string>("VTKEjesAf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKFarve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKSerieNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKanskaffet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaerktoejskasseId");

                    b.HasIndex("HaandVaerkerId")
                        .IsUnique();

                    b.ToTable("Vaerktoejskasses");
                });

            modelBuilder.Entity("DISPBackEnd.Models.Vaerktoej", b =>
                {
                    b.HasOne("DISPBackEnd.Models.Vaerktoejskasse", "vaerktoejskasse")
                        .WithMany("Vaerktoejs")
                        .HasForeignKey("VaerktoejskasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("vaerktoejskasse");
                });

            modelBuilder.Entity("DISPBackEnd.Models.Vaerktoejskasse", b =>
                {
                    b.HasOne("DISPBackEnd.Models.HaandVaerker", "HaandVaerker")
                        .WithOne("Vaerktoejskasse")
                        .HasForeignKey("DISPBackEnd.Models.Vaerktoejskasse", "HaandVaerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HaandVaerker");
                });

            modelBuilder.Entity("DISPBackEnd.Models.HaandVaerker", b =>
                {
                    b.Navigation("Vaerktoejskasse");
                });

            modelBuilder.Entity("DISPBackEnd.Models.Vaerktoejskasse", b =>
                {
                    b.Navigation("Vaerktoejs");
                });
#pragma warning restore 612, 618
        }
    }
}
