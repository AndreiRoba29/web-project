using Microsoft.EntityFrameworkCore.Migrations;

namespace Roba_Andrei_Proiect.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenParfum");

            migrationBuilder.AddColumn<int>(
                name: "GenID",
                table: "Parfum",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_GenID",
                table: "Parfum",
                column: "GenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parfum_Gen_GenID",
                table: "Parfum",
                column: "GenID",
                principalTable: "Gen",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parfum_Gen_GenID",
                table: "Parfum");

            migrationBuilder.DropIndex(
                name: "IX_Parfum_GenID",
                table: "Parfum");

            migrationBuilder.DropColumn(
                name: "GenID",
                table: "Parfum");

            migrationBuilder.CreateTable(
                name: "GenParfum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenID = table.Column<int>(type: "int", nullable: false),
                    ParfumID = table.Column<int>(type: "int", nullable: false)
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
    }
}
