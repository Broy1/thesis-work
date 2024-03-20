using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoSalesApp.Migrations
{
    /// <inheritdoc />
    public partial class Salesdbtagsremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecTags");

            migrationBuilder.DropTable(
                name: "SubCategoryTags");

            migrationBuilder.DropTable(
                name: "CategoryTags");

            migrationBuilder.AlterColumn<string>(
                name: "SellerUsername",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SellerPassword",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerUsername",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerPassword",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "SubCategoryTags",
                columns: table => new
                {
                    SubCategoryTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTagId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryTagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "SpecTags",
                columns: table => new
                {
                    SpecTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryTagId = table.Column<int>(type: "int", nullable: false),
                    SpecTagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_SpecTags_SubCategoryTagId",
                table: "SpecTags",
                column: "SubCategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryTags_CategoryTagId",
                table: "SubCategoryTags",
                column: "CategoryTagId");
        }
    }
}
