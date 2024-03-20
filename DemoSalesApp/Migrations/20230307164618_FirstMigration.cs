using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoSalesApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTags",
                columns: table => new
                {
                    CategoryTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTags", x => x.CategoryTagId);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryTags",
                columns: table => new
                {
                    SubCategoryTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryTagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryTags", x => x.SubCategoryTagId);
                    table.ForeignKey(
                        name: "FK_SubCategoryTags_CategoryTags_CategoryTagId",
                        column: x => x.CategoryTagId,
                        principalTable: "CategoryTags",
                        principalColumn: "CategoryTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductUploadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecTags",
                columns: table => new
                {
                    SpecTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecTagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecTags", x => x.SpecTagId);
                    table.ForeignKey(
                        name: "FK_SpecTags_SubCategoryTags_SubCategoryTagId",
                        column: x => x.SubCategoryTagId,
                        principalTable: "SubCategoryTags",
                        principalColumn: "SubCategoryTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecTags_SubCategoryTagId",
                table: "SpecTags",
                column: "SubCategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryTags_CategoryTagId",
                table: "SubCategoryTags",
                column: "CategoryTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecTags");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "SubCategoryTags");

            migrationBuilder.DropTable(
                name: "CategoryTags");
        }
    }
}
