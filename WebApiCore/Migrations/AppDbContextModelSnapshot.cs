﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCore.DataAccess;

namespace WebApiCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiCore.Entities.Det_Images_Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Imp_CreationDate");

                    b.Property<string>("Imp_Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Imp_Path")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Imp_ProductIdFk");

                    b.Property<bool>("Imp_Status");

                    b.HasKey("id");

                    b.HasIndex("Imp_ProductIdFk");

                    b.ToTable("Det_Images_Products");
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_Products_SubCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Psc_ProductIdFk");

                    b.Property<bool>("Psc_Status");

                    b.Property<int>("Psc_SubCategoryIdFk");

                    b.HasKey("Id");

                    b.HasIndex("Psc_ProductIdFk");

                    b.HasIndex("Psc_SubCategoryIdFk");

                    b.ToTable("Det_Products_SubCategories");
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_SalesHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Shi_BuyerIdFk");

                    b.Property<int>("Shi_CategoryIdFk");

                    b.Property<int>("Shi_CityIdFk");

                    b.Property<decimal>("Shi_ProductCurrentPrice");

                    b.Property<int>("Shi_ProductIdFk");

                    b.Property<int>("Shi_Quantity");

                    b.Property<int>("Shi_SaleIdFk");

                    b.Property<decimal>("Shi_TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("Shi_BuyerIdFk");

                    b.HasIndex("Shi_CategoryIdFk");

                    b.HasIndex("Shi_CityIdFk");

                    b.HasIndex("Shi_ProductIdFk");

                    b.HasIndex("Shi_SaleIdFk");

                    b.ToTable("Det_SalesHistory");
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_ShopCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Shc_DateCreation");

                    b.Property<int>("Shc_IdProductFk");

                    b.Property<int>("Shc_IdUserFk");

                    b.Property<int>("Shc_Quantity");

                    b.Property<int>("Shc_Status");

                    b.HasKey("Id");

                    b.HasIndex("Shc_IdProductFk");

                    b.ToTable("Det_ShopCar");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Cat_CreationDate");

                    b.Property<int>("Cat_CreationUserIdFk");

                    b.Property<string>("Cat_Description")
                        .HasMaxLength(256);

                    b.Property<string>("Cat_Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<bool>("Cat_Status");

                    b.HasKey("Id");

                    b.HasIndex("Cat_CreationUserIdFk");

                    b.ToTable("Dic_Categories");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cit_Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Dic_Cities");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Pro_CategoryIdFk");

                    b.Property<int>("Pro_CityIdFk");

                    b.Property<bool>("Pro_Condition");

                    b.Property<DateTime>("Pro_CreationDate");

                    b.Property<int>("Pro_CreationUserIdFk");

                    b.Property<string>("Pro_Description")
                        .HasMaxLength(512);

                    b.Property<string>("Pro_GuId")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("Pro_IsOutlet");

                    b.Property<string>("Pro_Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<decimal>("Pro_OutletPrice");

                    b.Property<int>("Pro_OutletValue");

                    b.Property<decimal>("Pro_Price");

                    b.Property<string>("Pro_PrincipalImage")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Pro_Stock");

                    b.Property<int>("Pro_SubCategoryIdFk");

                    b.Property<bool>("Pro_status");

                    b.HasKey("Id");

                    b.HasIndex("Pro_CategoryIdFk");

                    b.HasIndex("Pro_CityIdFk");

                    b.HasIndex("Pro_CreationUserIdFk");

                    b.HasIndex("Pro_SubCategoryIdFk");

                    b.ToTable("Dic_Products");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rol_Description")
                        .HasMaxLength(128);

                    b.Property<string>("Rol_Name")
                        .HasMaxLength(16);

                    b.Property<bool>("Rol_Status");

                    b.HasKey("Id");

                    b.ToTable("Dic_Rol");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Sal_BuyerId");

                    b.Property<decimal>("Sal_TotalPrice");

                    b.Property<DateTime>("Shi_SaleDate");

                    b.HasKey("Id");

                    b.HasIndex("Sal_BuyerId");

                    b.ToTable("Dic_Sales");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_SubCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Sca_CategoryIdFk");

                    b.Property<DateTime>("Sca_CreationDate");

                    b.Property<int>("Sca_CreationUserIdFk");

                    b.Property<string>("Sca_Description")
                        .HasMaxLength(256);

                    b.Property<string>("Sca_Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<bool>("Sca_Status");

                    b.HasKey("Id");

                    b.HasIndex("Sca_CategoryIdFk");

                    b.HasIndex("Sca_CreationUserIdFk");

                    b.ToTable("Dic_SubCategories");
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Use_Address")
                        .HasMaxLength(128);

                    b.Property<DateTime>("Use_CreationDate");

                    b.Property<string>("Use_Email")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Use_FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Use_HashPassword")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Use_LastName")
                        .HasMaxLength(64);

                    b.Property<int>("Use_Money");

                    b.Property<string>("Use_Phone")
                        .HasMaxLength(16);

                    b.Property<int>("Use_RolIdFk");

                    b.Property<bool>("Use_Status");

                    b.HasKey("Id");

                    b.HasIndex("Use_RolIdFk");

                    b.ToTable("Dic_Users");
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_Images_Products", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Products", "Product")
                        .WithMany()
                        .HasForeignKey("Imp_ProductIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_Products_SubCategories", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Products", "Product")
                        .WithMany()
                        .HasForeignKey("Psc_ProductIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_SubCategories", "SubCategory")
                        .WithMany()
                        .HasForeignKey("Psc_SubCategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_SalesHistory", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Users", "UserBuyer")
                        .WithMany()
                        .HasForeignKey("Shi_BuyerIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Categories", "Category")
                        .WithMany()
                        .HasForeignKey("Shi_CategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Cities", "City")
                        .WithMany()
                        .HasForeignKey("Shi_CityIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Products", "Producto")
                        .WithMany()
                        .HasForeignKey("Shi_ProductIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Sales", "Sale")
                        .WithMany()
                        .HasForeignKey("Shi_SaleIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Det_ShopCar", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Products", "Product")
                        .WithMany()
                        .HasForeignKey("Shc_IdProductFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Categories", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Users", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("Cat_CreationUserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Products", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Categories", "PrincipalCategory")
                        .WithMany()
                        .HasForeignKey("Pro_CategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Cities", "City")
                        .WithMany()
                        .HasForeignKey("Pro_CityIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Users", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("Pro_CreationUserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_SubCategories", "SubCategory")
                        .WithMany()
                        .HasForeignKey("Pro_SubCategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Sales", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Users", "UserBuyer")
                        .WithMany()
                        .HasForeignKey("Sal_BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_SubCategories", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Categories", "Category")
                        .WithMany()
                        .HasForeignKey("Sca_CategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCore.Entities.Dic_Users", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("Sca_CreationUserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCore.Entities.Dic_Users", b =>
                {
                    b.HasOne("WebApiCore.Entities.Dic_Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("Use_RolIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
