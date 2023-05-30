using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Callapp.Infrastructure.Migrations
{
    public partial class addUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_UserProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProfileId",
                table: "Users",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_UserProfileId",
                table: "Users",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
