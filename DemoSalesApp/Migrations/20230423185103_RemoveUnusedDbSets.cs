using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoSalesApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerUsername = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });
        }
    }
}
