using Microsoft.EntityFrameworkCore.Migrations;

namespace Roba_Andrei_Proiect.Migrations
{
    public partial class AromaParfum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Parfum",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Aroma",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAroma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aroma", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeBrand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AromaParfum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumID = table.Column<int>(nullable: false),
                    AromaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AromaParfum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AromaParfum_Aroma_AromaID",
                        column: x => x.AromaID,
                        principalTable: "Aroma",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AromaParfum_Parfum_ParfumID",
                        column: x => x.ParfumID,
                        principalTable: "Parfum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_BrandID",
                table: "Parfum",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_AromaParfum_AromaID",
                table: "AromaParfum",
                column: "AromaID");

            migrationBuilder.CreateIndex(
                name: "IX_AromaParfum_ParfumID",
                table: "AromaParfum",
                column: "ParfumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parfum_Brand_BrandID",
                table: "Parfum",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parfum_Brand_BrandID",
                table: "Parfum");

            migrationBuilder.DropTable(
                name: "AromaParfum");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Aroma");

            migrationBuilder.DropIndex(
                name: "IX_Parfum_BrandID",
                table: "Parfum");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Parfum");
        }
    }
}
