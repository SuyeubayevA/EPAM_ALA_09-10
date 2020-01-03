using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ALA_07_MVC_try3.Migrations
{
    public partial class RoleCreation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "User",
                nullable: true);
        }
    }
}
