using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobuskaStanicaInternetProgramiranje.Migrations.AutobuskaStanicaDb
{
    /// <inheritdoc />
    public partial class AutobusjeprevoznikalinemavezesadaIspravka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sedisteKompanije",
                table: "Autobusi",
                newName: "SedisteKompanije");

            migrationBuilder.RenameColumn(
                name: "sajtKompanije",
                table: "Autobusi",
                newName: "SajtKompanije");

            migrationBuilder.RenameColumn(
                name: "emailKompanije",
                table: "Autobusi",
                newName: "EmailKompanije");

            migrationBuilder.RenameColumn(
                name: "brojTelefonaKompanije",
                table: "Autobusi",
                newName: "BrojTelefonaKompanije");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SedisteKompanije",
                table: "Autobusi",
                newName: "sedisteKompanije");

            migrationBuilder.RenameColumn(
                name: "SajtKompanije",
                table: "Autobusi",
                newName: "sajtKompanije");

            migrationBuilder.RenameColumn(
                name: "EmailKompanije",
                table: "Autobusi",
                newName: "emailKompanije");

            migrationBuilder.RenameColumn(
                name: "BrojTelefonaKompanije",
                table: "Autobusi",
                newName: "brojTelefonaKompanije");
        }
    }
}
