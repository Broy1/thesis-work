using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoSalesApp.Migrations.TagDb
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "SpecTags");

            migrationBuilder.DropTable(
                name: "SubCategoryTags");

            migrationBuilder.DropTable(
                name: "CategoryTags");
        }
    }
}
