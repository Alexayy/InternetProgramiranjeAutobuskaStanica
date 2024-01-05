using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations
{
    /// <inheritdoc />
    public partial class ResetDbBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autobusi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BrojSedista = table.Column<int>(type: "integer", nullable: false),
                    SedisteKompanije = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    BrojTelefonaKompanije = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EmailKompanije = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SajtKompanije = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SlikaAutobusa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobusi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RezervacijaID = table.Column<int>(type: "integer", nullable: false),
                    DatumKupovine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uloga = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SlikaKorisnika = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Linije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolaznaStanica = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DolaznaStanica = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    VremePolaska = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LinijaID = table.Column<int>(type: "integer", nullable: false),
                    SedisteID = table.Column<int>(type: "integer", nullable: false),
                    KorisnikID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stajalista",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LinijaID = table.Column<int>(type: "integer", nullable: false),
                    StanicaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stajalista", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stanice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Adresa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKarta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KorisnikID = table.Column<int>(type: "integer", nullable: false),
                    KartaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKarta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KorisnikKarta_Karte_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Karte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKarta_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKarta_KartaID",
                table: "KorisnikKarta",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKarta_KorisnikID",
                table: "KorisnikKarta",
                column: "KorisnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autobusi");

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

            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
