using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    MitarbeiterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vorname = table.Column<string>(type: "text", nullable: false),
                    Nachname = table.Column<string>(type: "text", nullable: false),
                    Personalnummer = table.Column<string>(type: "text", nullable: false),
                    Aktiv = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.MitarbeiterID);
                });

            migrationBuilder.CreateTable(
                name: "RFID_Karte",
                columns: table => new
                {
                    KartenID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RFID_UID = table.Column<string>(type: "text", nullable: false),
                    MitarbeiterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFID_Karte", x => x.KartenID);
                });

            migrationBuilder.CreateTable(
                name: "Urlaub",
                columns: table => new
                {
                    UrlaubsID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enddatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Startdatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Genehmigt = table.Column<bool>(type: "boolean", nullable: false),
                    MitarbeiterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urlaub", x => x.UrlaubsID);
                });

            migrationBuilder.CreateTable(
                name: "Zeitbuchung",
                columns: table => new
                {
                    BuchungsID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Zeitstempel = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Buchungstyp = table.Column<string>(type: "text", nullable: false),
                    MitarbeiterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zeitbuchung", x => x.BuchungsID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mitarbeiter");

            migrationBuilder.DropTable(
                name: "RFID_Karte");

            migrationBuilder.DropTable(
                name: "Urlaub");

            migrationBuilder.DropTable(
                name: "Zeitbuchung");
        }
    }
}
