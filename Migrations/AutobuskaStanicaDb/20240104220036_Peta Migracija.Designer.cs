﻿// <auto-generated />
using System;
using AutobuskaStanicaInternetProgramiranje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    [DbContext(typeof(AutobuskaStanicaDbContext))]
    [Migration("20240104220036_Peta Migracija")]
    partial class PetaMigracija
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SlikaKorisnika")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uloga")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije.KorisnikKarta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("KartaID")
                        .HasColumnType("integer");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("integer");

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

                    b.Property<int>("KorisnikID")
                        .HasColumnType("integer");

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
