using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesSoutenaces.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirst1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENSEIGNANT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENSEIGNANT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ETUDIANT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETUDIANT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SOCIETE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOCIETE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PFE",
                columns: table => new
                {
                    PFEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE", x => x.PFEID);
                    table.ForeignKey(
                        name: "FK_PFE_ENSEIGNANT_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "ENSEIGNANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_SOCIETE_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "SOCIETE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PFE_ETUDIANT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    EtudiantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE_ETUDIANT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PFE_ETUDIANT_ETUDIANT_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "ETUDIANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_ETUDIANT_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFE_EncadrantID",
                table: "PFE",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_SocieteID",
                table: "PFE",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_ETUDIANT_EtudiantID",
                table: "PFE_ETUDIANT",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_ETUDIANT_PFEID",
                table: "PFE_ETUDIANT",
                column: "PFEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PFE_ETUDIANT");

            migrationBuilder.DropTable(
                name: "ETUDIANT");

            migrationBuilder.DropTable(
                name: "PFE");

            migrationBuilder.DropTable(
                name: "ENSEIGNANT");

            migrationBuilder.DropTable(
                name: "SOCIETE");
        }
    }
}
