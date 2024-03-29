﻿// <auto-generated />
using System;
using AutobuskaStanicaInternetProgramiranje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Autobus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("BrojSedista")
                        .HasColumnType("integer");

                    b.Property<string>("BrojTelefonaKompanije")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailKompanije")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SajtKompanije")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SedisteKompanije")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SlikaAutobusa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Autobusi");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Karta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RezervacijaID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.KorisnikKarta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("KartaID")
                        .HasColumnType("integer");

                    b.Property<string>("KorisnikID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("KorisnikKarta");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Linija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("DolaznaStanica")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PolaznaStanica")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("VremePolaska")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Linije");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("KorisnikID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LinijaID")
                        .HasColumnType("integer");

                    b.Property<int>("SedisteID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Stajaliste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("LinijaID")
                        .HasColumnType("integer");

                    b.Property<int>("StanicaID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Stajalista");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Stanica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Stanice");
                });
#pragma warning restore 612, 618
        }
    }
}
