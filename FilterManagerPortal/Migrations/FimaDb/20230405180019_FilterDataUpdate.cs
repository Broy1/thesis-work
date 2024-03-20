using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilterManagerPortal.Migrations.FimaDb
{
    /// <inheritdoc />
    public partial class FilterDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filters_AspNetUsers_FimaUserId",
                table: "Filters");

            migrationBuilder.DropForeignKey(
                name: "FK_Filters_User_UserId",
                table: "Filters");

            migrationBuilder.DropTable(
                name: "EmailOptions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Filters_FimaUserId",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "FimaUserId",
                table: "Filters");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Filters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_AspNetUsers_UserId",
                table: "Filters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filters_AspNetUsers_UserId",
                table: "Filters");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Filters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FimaUserId",
                table: "Filters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOpsId = table.Column<int>(type: "int", nullable: true),
                    Filterids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EmailOptions",
                columns: table => new
                {
                    EmailOpsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomEmailText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendEmailToSeller = table.Column<bool>(type: "bit", nullable: false),
                    UseTemplate = table.Column<bool>(type: "bit", nullable: false),
                    WantNotification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOptions", x => x.EmailOpsId);
                    table.ForeignKey(
                        name: "FK_EmailOptions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filters_FimaUserId",
                table: "Filters",
                column: "FimaUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOptions_UserId",
                table: "EmailOptions",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_AspNetUsers_FimaUserId",
                table: "Filters",
                column: "FimaUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_User_UserId",
                table: "Filters",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
