using Microsoft.EntityFrameworkCore.Migrations;

namespace Roba_Andrei_Proiect.Migrations
{
    public partial class GenParfum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeGen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GenParfum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumID = table.Column<int>(nullable: false),
                    GenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenParfum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GenParfum_Gen_GenID",
                        column: x => x.GenID,
                        principalTable: "Gen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenParfum_Parfum_ParfumID",
                        column: x => x.ParfumID,
                        principalTable: "Parfum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenParfum_GenID",
                table: "GenParfum",
                column: "GenID");

            migrationBuilder.CreateIndex(
                name: "IX_GenParfum_ParfumID",
                table: "GenParfum",
                column: "ParfumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenParfum");

            migrationBuilder.DropTable(
                name: "Gen");
        }
    }
}
