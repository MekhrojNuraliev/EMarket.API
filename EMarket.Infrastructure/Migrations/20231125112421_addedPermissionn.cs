using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedPermissionn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionId",
                table: "Users",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_PermissionId",
                table: "Users",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_PermissionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PermissionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Users");
        }
    }
}
