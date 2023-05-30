using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Callapp.Infrastructure.Migrations
{
    public partial class changeIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "UserProfiles");
        }
    }
}
