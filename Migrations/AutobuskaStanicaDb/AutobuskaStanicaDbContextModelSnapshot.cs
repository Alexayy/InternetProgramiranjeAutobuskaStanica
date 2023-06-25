﻿// <auto-generated />
using System;
using AutobuskaStanicaInternetProgramiranje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    [DbContext(typeof(AutobuskaStanicaDbContext))]
    partial class AutobuskaStanicaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Autobus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrojSedista")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Autobusi");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Karta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnType("datetime2");

                    b.Property<int>("RezervacijaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Linija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DolaznaStanica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolaznaStanica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremePolaska")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Linije");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("LinijaID")
                        .HasColumnType("int");

                    b.Property<int>("SedisteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Stajaliste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("LinijaID")
                        .HasColumnType("int");

                    b.Property<int>("StanicaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Stajalista");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Stanica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Stanice");
                });
#pragma warning restore 612, 618
        }
    }
}
