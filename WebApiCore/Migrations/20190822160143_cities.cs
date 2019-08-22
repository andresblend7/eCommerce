using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore.Migrations
{
    public partial class cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pro_CityIdFk",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Pro_IsOutlet",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Pro_OutletPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cit_Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pro_CityIdFk",
                table: "Products",
                column: "Pro_CityIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_Pro_CityIdFk",
                table: "Products",
                column: "Pro_CityIdFk",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_Pro_CityIdFk",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Products_Pro_CityIdFk",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pro_CityIdFk",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pro_IsOutlet",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pro_OutletPrice",
                table: "Products");
        }
    }
}
