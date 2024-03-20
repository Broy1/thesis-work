﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilterManagerPortal.Migrations.FimaDb
{
    /// <inheritdoc />
    public partial class PropertyNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FimaUserId",
                table: "Filters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FimaUserId",
                table: "Filters");
        }
    }
}
