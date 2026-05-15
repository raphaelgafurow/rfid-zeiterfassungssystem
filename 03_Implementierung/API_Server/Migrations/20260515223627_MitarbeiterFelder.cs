using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Server.Migrations
{
    /// <inheritdoc />
    public partial class MitarbeiterFelder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abteilung",
                table: "Mitarbeiter",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Arbeitszeitkonto",
                table: "Mitarbeiter",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rolle",
                table: "Mitarbeiter",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Urlaubstage",
                table: "Mitarbeiter",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abteilung",
                table: "Mitarbeiter");

            migrationBuilder.DropColumn(
                name: "Arbeitszeitkonto",
                table: "Mitarbeiter");

            migrationBuilder.DropColumn(
                name: "Rolle",
                table: "Mitarbeiter");

            migrationBuilder.DropColumn(
                name: "Urlaubstage",
                table: "Mitarbeiter");
        }
    }
}
