using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore.Migrations
{
    public partial class initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rol_Name = table.Column<string>(maxLength: 16, nullable: true),
                    Rol_Description = table.Column<string>(maxLength: 128, nullable: true),
                    Rol_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Use_RolIdFk = table.Column<int>(nullable: false),
                    Use_FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    Use_LastName = table.Column<string>(maxLength: 64, nullable: true),
                    Use_Email = table.Column<string>(maxLength: 32, nullable: false),
                    Use_Address = table.Column<string>(maxLength: 128, nullable: true),
                    Use_Phone = table.Column<string>(maxLength: 16, nullable: true),
                    Use_HashPassword = table.Column<string>(maxLength: 256, nullable: false),
                    Use_CreationDate = table.Column<DateTime>(nullable: false),
                    Use_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Rol_Use_RolIdFk",
                        column: x => x.Use_RolIdFk,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cat_CreationUserIdFk = table.Column<int>(nullable: false),
                    Cat_Name = table.Column<string>(maxLength: 32, nullable: false),
                    Cat_Description = table.Column<string>(maxLength: 256, nullable: true),
                    Cat_CreationDate = table.Column<DateTime>(nullable: false),
                    Cat_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_Cat_CreationUserIdFk",
                        column: x => x.Cat_CreationUserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sal_BuyerId = table.Column<int>(nullable: false),
                    Sal_TotalPrice = table.Column<double>(nullable: false),
                    Shi_SaleDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_Sal_BuyerId",
                        column: x => x.Sal_BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pro_CategoryIdFk = table.Column<int>(nullable: false),
                    Pro_GuId = table.Column<string>(maxLength: 64, nullable: false),
                    Pro_CreationUserIdFk = table.Column<int>(nullable: false),
                    Pro_Name = table.Column<string>(maxLength: 32, nullable: false),
                    Pro_Description = table.Column<int>(maxLength: 512, nullable: false),
                    Pro_Price = table.Column<double>(nullable: false),
                    Pro_Stock = table.Column<int>(nullable: false),
                    Pro_PrincipalImage = table.Column<string>(maxLength: 64, nullable: true),
                    Pro_CreationDate = table.Column<DateTime>(nullable: false),
                    Pro_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Pro_CategoryIdFk",
                        column: x => x.Pro_CategoryIdFk,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Users_Pro_CreationUserIdFk",
                        column: x => x.Pro_CreationUserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sca_CategoryIdFk = table.Column<int>(nullable: false),
                    Sca_CreationUserIdFk = table.Column<int>(nullable: false),
                    Sca_Name = table.Column<string>(maxLength: 16, nullable: false),
                    Sca_Description = table.Column<string>(maxLength: 256, nullable: true),
                    Sca_CreationDate = table.Column<DateTime>(nullable: false),
                    Sca_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_Sca_CategoryIdFk",
                        column: x => x.Sca_CategoryIdFk,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubCategories_Users_Sca_CreationUserIdFk",
                        column: x => x.Sca_CreationUserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Images_Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imp_ProductIdFk = table.Column<int>(nullable: false),
                    Imp_Name = table.Column<string>(maxLength: 64, nullable: true),
                    Imp_CreationDate = table.Column<DateTime>(nullable: false),
                    Imp_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_Products_Products_Imp_ProductIdFk",
                        column: x => x.Imp_ProductIdFk,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SalesHistory_Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Shi_SaleIdFk = table.Column<int>(nullable: false),
                    Shi_BuyerIdFk = table.Column<int>(nullable: false),
                    Shi_ProductIdFk = table.Column<int>(nullable: false),
                    Shi_ProductCurrentPrice = table.Column<double>(nullable: false),
                    Shi_Quantity = table.Column<int>(nullable: false),
                    Shi_TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesHistory_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesHistory_Details_Users_Shi_BuyerIdFk",
                        column: x => x.Shi_BuyerIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SalesHistory_Details_Products_Shi_ProductIdFk",
                        column: x => x.Shi_ProductIdFk,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SalesHistory_Details_Sales_Shi_SaleIdFk",
                        column: x => x.Shi_SaleIdFk,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products_SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Psc_ProductIdFk = table.Column<int>(nullable: false),
                    Psc_SubCategoryIdFk = table.Column<int>(nullable: false),
                    Psc_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_Products_Psc_ProductIdFk",
                        column: x => x.Psc_ProductIdFk,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategories_Psc_SubCategoryIdFk",
                        column: x => x.Psc_SubCategoryIdFk,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Cat_CreationUserIdFk",
                table: "Categories",
                column: "Cat_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Products_Imp_ProductIdFk",
                table: "Images_Products",
                column: "Imp_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pro_CategoryIdFk",
                table: "Products",
                column: "Pro_CategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Pro_CreationUserIdFk",
                table: "Products",
                column: "Pro_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategories_Psc_ProductIdFk",
                table: "Products_SubCategories",
                column: "Psc_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategories_Psc_SubCategoryIdFk",
                table: "Products_SubCategories",
                column: "Psc_SubCategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Sal_BuyerId",
                table: "Sales",
                column: "Sal_BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesHistory_Details_Shi_BuyerIdFk",
                table: "SalesHistory_Details",
                column: "Shi_BuyerIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SalesHistory_Details_Shi_ProductIdFk",
                table: "SalesHistory_Details",
                column: "Shi_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SalesHistory_Details_Shi_SaleIdFk",
                table: "SalesHistory_Details",
                column: "Shi_SaleIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Sca_CategoryIdFk",
                table: "SubCategories",
                column: "Sca_CategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Sca_CreationUserIdFk",
                table: "SubCategories",
                column: "Sca_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Use_RolIdFk",
                table: "Users",
                column: "Use_RolIdFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images_Products");

            migrationBuilder.DropTable(
                name: "Products_SubCategories");

            migrationBuilder.DropTable(
                name: "SalesHistory_Details");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
