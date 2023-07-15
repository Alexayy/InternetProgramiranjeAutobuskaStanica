using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    /// <inheritdoc />
    public partial class Autobusjeprevoznikalinemavezesada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "brojTelefonaKompanije",
                table: "Autobusi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "emailKompanije",
                table: "Autobusi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sajtKompanije",
                table: "Autobusi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sedisteKompanije",
                table: "Autobusi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brojTelefonaKompanije",
                table: "Autobusi");

            migrationBuilder.DropColumn(
                name: "emailKompanije",
                table: "Autobusi");

            migrationBuilder.DropColumn(
                name: "sajtKompanije",
                table: "Autobusi");

            migrationBuilder.DropColumn(
                name: "sedisteKompanije",
                table: "Autobusi");
        }
    }
}
