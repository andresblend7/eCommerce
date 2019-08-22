using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore.Migrations
{
    public partial class decimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pro_Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Pro_OutletPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Pro_Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "Pro_OutletPrice",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
