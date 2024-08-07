﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autobusi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojSedista = table.Column<int>(type: "int", nullable: false),
                    SedisteKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefonaKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SajtKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaAutobusa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobusi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervacijaID = table.Column<int>(type: "int", nullable: false),
                    DatumKupovine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKarta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKarta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Linije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolaznaStanica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DolaznaStanica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremePolaska = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaID = table.Column<int>(type: "int", nullable: false),
                    SedisteID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stajalista",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinijaID = table.Column<int>(type: "int", nullable: false),
                    StanicaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stajalista", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stanice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanice", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autobusi");

            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "KorisnikKarta");

            migrationBuilder.DropTable(
                name: "Linije");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Stajalista");

            migrationBuilder.DropTable(
                name: "Stanice");
        }
    }
}
