using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dic_Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cit_Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dic_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dic_Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rol_Name = table.Column<string>(maxLength: 16, nullable: true),
                    Rol_Description = table.Column<string>(maxLength: 128, nullable: true),
                    Rol_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dic_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dic_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Use_RolIdFk = table.Column<int>(nullable: false),
                    Use_Money = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Dic_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dic_Users_Dic_Rol_Use_RolIdFk",
                        column: x => x.Use_RolIdFk,
                        principalTable: "Dic_Rol",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dic_Categories",
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
                    table.PrimaryKey("PK_Dic_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dic_Categories_Dic_Users_Cat_CreationUserIdFk",
                        column: x => x.Cat_CreationUserIdFk,
                        principalTable: "Dic_Users",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dic_Sales",
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
                    table.PrimaryKey("PK_Dic_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dic_Sales_Dic_Users_Sal_BuyerId",
                        column: x => x.Sal_BuyerId,
                        principalTable: "Dic_Users",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dic_Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pro_CategoryIdFk = table.Column<int>(nullable: false),
                    Pro_CreationUserIdFk = table.Column<int>(nullable: false),
                    Pro_CityIdFk = table.Column<int>(nullable: false),
                    Pro_GuId = table.Column<string>(maxLength: 64, nullable: false),
                    Pro_Condition = table.Column<bool>(nullable: false),
                    Pro_Name = table.Column<string>(maxLength: 64, nullable: false),
                    Pro_Description = table.Column<string>(maxLength: 512, nullable: true),
                    Pro_Price = table.Column<decimal>(nullable: false),
                    Pro_Stock = table.Column<int>(nullable: false),
                    Pro_OutletPrice = table.Column<decimal>(nullable: false),
                    Pro_IsOutlet = table.Column<bool>(nullable: false),
                    Pro_PrincipalImage = table.Column<string>(maxLength: 64, nullable: false),
                    Pro_CreationDate = table.Column<DateTime>(nullable: false),
                    Pro_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dic_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dic_Products_Dic_Categories_Pro_CategoryIdFk",
                        column: x => x.Pro_CategoryIdFk,
                        principalTable: "Dic_Categories",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dic_Products_Dic_Cities_Pro_CityIdFk",
                        column: x => x.Pro_CityIdFk,
                        principalTable: "Dic_Cities",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dic_Products_Dic_Users_Pro_CreationUserIdFk",
                        column: x => x.Pro_CreationUserIdFk,
                        principalTable: "Dic_Users",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dic_SubCategories",
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
                    table.PrimaryKey("PK_Dic_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dic_SubCategories_Dic_Categories_Sca_CategoryIdFk",
                        column: x => x.Sca_CategoryIdFk,
                        principalTable: "Dic_Categories",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dic_SubCategories_Dic_Users_Sca_CreationUserIdFk",
                        column: x => x.Sca_CreationUserIdFk,
                        principalTable: "Dic_Users",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Det_Images_Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imp_ProductIdFk = table.Column<int>(nullable: false),
                    Imp_Name = table.Column<string>(maxLength: 64, nullable: false),
                    Imp_CreationDate = table.Column<DateTime>(nullable: false),
                    Imp_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Det_Images_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Det_Images_Products_Dic_Products_Imp_ProductIdFk",
                        column: x => x.Imp_ProductIdFk,
                        principalTable: "Dic_Products",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Det_SalesHistory",
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
                    table.PrimaryKey("PK_Det_SalesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Det_SalesHistory_Dic_Users_Shi_BuyerIdFk",
                        column: x => x.Shi_BuyerIdFk,
                        principalTable: "Dic_Users",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Det_SalesHistory_Dic_Products_Shi_ProductIdFk",
                        column: x => x.Shi_ProductIdFk,
                        principalTable: "Dic_Products",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Det_SalesHistory_Dic_Sales_Shi_SaleIdFk",
                        column: x => x.Shi_SaleIdFk,
                        principalTable: "Dic_Sales",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Det_Products_SubCategories",
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
                    table.PrimaryKey("PK_Det_Products_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Det_Products_SubCategories_Dic_Products_Psc_ProductIdFk",
                        column: x => x.Psc_ProductIdFk,
                        principalTable: "Dic_Products",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Det_Products_SubCategories_Dic_SubCategories_Psc_SubCategoryIdFk",
                        column: x => x.Psc_SubCategoryIdFk,
                        principalTable: "Dic_SubCategories",
                        principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Det_Images_Products_Imp_ProductIdFk",
                table: "Det_Images_Products",
                column: "Imp_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Products_SubCategories_Psc_ProductIdFk",
                table: "Det_Products_SubCategories",
                column: "Psc_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Products_SubCategories_Psc_SubCategoryIdFk",
                table: "Det_Products_SubCategories",
                column: "Psc_SubCategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Det_SalesHistory_Shi_BuyerIdFk",
                table: "Det_SalesHistory",
                column: "Shi_BuyerIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Det_SalesHistory_Shi_ProductIdFk",
                table: "Det_SalesHistory",
                column: "Shi_ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Det_SalesHistory_Shi_SaleIdFk",
                table: "Det_SalesHistory",
                column: "Shi_SaleIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Categories_Cat_CreationUserIdFk",
                table: "Dic_Categories",
                column: "Cat_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Products_Pro_CategoryIdFk",
                table: "Dic_Products",
                column: "Pro_CategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Products_Pro_CityIdFk",
                table: "Dic_Products",
                column: "Pro_CityIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Products_Pro_CreationUserIdFk",
                table: "Dic_Products",
                column: "Pro_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Sales_Sal_BuyerId",
                table: "Dic_Sales",
                column: "Sal_BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_SubCategories_Sca_CategoryIdFk",
                table: "Dic_SubCategories",
                column: "Sca_CategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_SubCategories_Sca_CreationUserIdFk",
                table: "Dic_SubCategories",
                column: "Sca_CreationUserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dic_Users_Use_RolIdFk",
                table: "Dic_Users",
                column: "Use_RolIdFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Det_Images_Products");

            migrationBuilder.DropTable(
                name: "Det_Products_SubCategories");

            migrationBuilder.DropTable(
                name: "Det_SalesHistory");

            migrationBuilder.DropTable(
                name: "Dic_SubCategories");

            migrationBuilder.DropTable(
                name: "Dic_Products");

            migrationBuilder.DropTable(
                name: "Dic_Sales");

            migrationBuilder.DropTable(
                name: "Dic_Categories");

            migrationBuilder.DropTable(
                name: "Dic_Cities");

            migrationBuilder.DropTable(
                name: "Dic_Users");

            migrationBuilder.DropTable(
                name: "Dic_Rol");
        }
    }
}
