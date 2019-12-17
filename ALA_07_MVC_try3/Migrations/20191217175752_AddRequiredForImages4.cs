using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ALA_07_MVC_try3.Migrations
{
    public partial class AddRequiredForImages4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Award");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "User",
                nullable: true,
                oldClrType: typeof(byte[]));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "User",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Award",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
