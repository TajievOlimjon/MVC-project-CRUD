using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CtegoryId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ctegory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ctegory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CtegoryId",
                table: "Products",
                column: "CtegoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ctegory_CtegoryId",
                table: "Products",
                column: "CtegoryId",
                principalTable: "Ctegory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ctegory_CtegoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Ctegory");

            migrationBuilder.DropIndex(
                name: "IX_Products_CtegoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CtegoryId",
                table: "Products");
        }
    }
}
