﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilterManagerPortal.Migrations.FimaDb
{
    /// <inheritdoc />
    public partial class FilterPropertyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilterCondition",
                table: "Filters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilterCondition",
                table: "Filters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
