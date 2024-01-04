using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    /// <inheritdoc />
    public partial class PetaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaKorisnika",
                table: "Korisnici",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlikaAutobusa",
                table: "Autobusi",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaKorisnika",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "SlikaAutobusa",
                table: "Autobusi");
        }
    }
}
